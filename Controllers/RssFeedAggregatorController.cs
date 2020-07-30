
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using RssFeedAggregator.Domain;
using RssFeedAggregator.Managers;
using RssFeedAggregator.Interfaces;
// using Microsoft.EntityFrameworkCore;

using System.Linq;

namespace RssFeedAggregator.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class RssFeedAggregatorController : ControllerBase
    {
        // private readonly RssFeedAggregatorDbContext _context;
        protected ISqlManager<RssFeed> Manager {get; private set;}

        public RssFeedAggregatorController(ISqlManager<RssFeed> manager)
        {
            // _context = context;
            Manager = manager;
        }

        #region OLD_IMPLEMENTATION   
        // [HttpGet("IsAlive")]
        // public ActionResult IsAlive()
        // {
        //     return Ok();
        // }

        // [HttpPost("feed")]
        // public ActionResult AddFeed([FromBody] RssFeed model)
        // {
        //    if (model != null )
        //     {
        //     _context.Add(model);
        //     _context.SaveChanges();

        //     return Ok(model);
        //     }
            
        //     return NoContent();
        // }

        // [HttpPost("feed/{id}")]
        // public ActionResult AddItem2Feed([FromBody] RssFeedItem item, int id)
        // {
        //    if (id != 0 )
        //     {
        //         var  model = _context.RssFeeds.Where(p => p.Id == id).Include(feedItems => feedItems.Items).First() as RssFeed;
                
        //         if(model.Items != null ) 
        //         {
        //             model.Items.Add(item);
        //         }

        //         _context.Update(model);
        //         _context.SaveChanges();

        //     return Ok(model);
        //     }
            
        //     return NoContent();
        // }

        [HttpGet("feeds")]
        public async Task<IEnumerable<RssFeed>> GetFeeds()
        {
            var feeds = await Manager.GetAll();
            return feeds;

        }

        [HttpGet("feed/{id}")]
        public async Task<ActionResult<RssFeed>> GetFeed(int id)
        {
            var feed = await Manager.Get(id);
            return feed;
        }

        // [HttpDelete("feed/{id}")]
        // public ActionResult<RssFeed> DeleteFeed(int id)
        // {
        //     if(id != 0)
        //     {
        //         var model = _context.RssFeeds.Where(p => p.Id == id).Include(i => i.Items).First();

        //         foreach(var item in model.Items)
        //         {
        //             _context.Remove(item);
        //         }

        //         _context.Remove(model);
        //         _context.SaveChanges();

        //         return Ok(model);
        //     }

        //     return NoContent();
        // }

        // [HttpDelete("feed/{id}/item/{itemId}")]
        // public ActionResult<RssFeedItem> DeleteFeedItem(int id, int itemId)
        // {
        //     if(id != 0 && itemId != 0)
        //     {
        //         var model = _context.RssFeeds.Where(p => p.Id == id).Include(i => i.Items).First();

        //         foreach(var feedItem in model.Items)
        //         {
        //             if(feedItem.Id == itemId)
        //             {
        //                 _context.Remove(feedItem);
        //                 _context.SaveChanges();
        //                 return Ok(feedItem);
                        
        //             }
        //         }
        //     }

        //     return NoContent();
        // }
        #endregion
    }
}

/* NOTES:
    1. To return action result from http request without any data type use: IActionResult
    2. To return action result with data from http request use: ActionResult<T> 
*/
