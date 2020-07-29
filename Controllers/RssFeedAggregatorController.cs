
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

        [HttpPost]
        public IActionResult InserFeed()
        {
            var feed = new RssFeed() 
            {
                Title = "Test feed nr 1",
                Description = "Test feed nr 1 description",
                Items = new List<RssFeedItem>() 
                {
                    new RssFeedItem() 
                    {
                        Date = new System.DateTime(2020,05,26),
                        Title = "Rss item nr 1",
                        Description = "Rss item desc nr 1",
                        Url = "http://localhost:5000/IsAlive"
                    }
                }
            };

            _context.Add(feed);
            _context.SaveChanges();

            return Ok();

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
