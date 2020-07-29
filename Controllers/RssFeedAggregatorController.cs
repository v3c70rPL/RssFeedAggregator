
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RssFeedAggregator.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace RssFeedAggregator.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class RssFeedAggregatorController : ControllerBase
    {
        private readonly RssFeedAggregatorDbContext _context;

        public RssFeedAggregatorController(RssFeedAggregatorDbContext context)
        {
            _context = context;
        }
        
        [HttpGet("IsAlive")]
        public IActionResult IsAlive()
        {
            return Ok();
        }

        [HttpPost("feed")]
        public IActionResult AddFeed([FromBody] RssFeed model)
        {
           if (model != null )
            {
            _context.Add(model);
            _context.SaveChanges();

            return Ok(model);
            }
            
            return NoContent();
        }

        [HttpPost("feed/{id}")]
        public IActionResult AddItem2Feed([FromBody] RssFeedItem item, int id)
        {
           if (id != 0 )
            {
                var  model = _context.RssFeeds.Where(p => p.Id == id).Include(feedItems => feedItems.Items).First() as RssFeed;
                
                if(model.Items != null ) 
                {
                    model.Items.Add(item);
                }

                _context.Update(model);
                _context.SaveChanges();

            return Ok(model);
            }
            
            return NoContent();
        }

        [HttpGet("GetFeeds")]
        public IEnumerable<RssFeed> GetFeeds()
        {
            var feeds = _context.RssFeeds
                .Include(feed => feed.Items).ToList();
            return feeds;

        }

    }
}

/* NOTES:
    1. To return action result from http request without any data type use: IActionResult
    2. To return action result with data from http request use: ActionResult<T> 
*/
