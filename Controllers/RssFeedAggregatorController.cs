
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using RssFeedAggregator.Domain;
using RssFeedAggregator.Interfaces;

using System.Linq;

namespace RssFeedAggregator.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class RssFeedAggregatorController : ControllerBase
    {
        protected ISqlManager<RssFeed> Manager {get; private set;}

        public RssFeedAggregatorController(ISqlManager<RssFeed> manager)
        {
            Manager = manager;
        }


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

        [HttpPost("feed")]
        public async Task<ActionResult<RssFeed>> AddFeed([FromBody] RssFeed model)
        {
           var feed = await Manager.Add(model);
           return feed;
        }

        [HttpPut("feed/{id}")]
        public async Task<ActionResult<RssFeed>> UpdateFeed([FromBody] RssFeed model)
        {
            var feed = await Manager.Update(model);
            return feed;
        }

        [HttpDelete("feed/{id}")]
        public async Task<ActionResult<RssFeed>> RemoveFeed(int id)
        {
            var result = await Manager.Delete(id);
            return result;
        }

        [HttpGet("isAlive")]
        public ActionResult<bool> IsAlive()
        {
            return true;
        }

        [HttpGet("GetExample")]
        public ActionResult<RssFeed> GetExample()
        {
            var model = new RssFeed();
            model.Items = new List<RssFeedItem>()
            {
                new RssFeedItem()
            };

            return model;
        }
    }
}

/* NOTES:
    1. To return action result from http request without any data type use: IActionResult
    2. To return action result with data from http request use: ActionResult<T> 
*/
