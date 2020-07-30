using RssFeedAggregator.Interfaces;
using RssFeedAggregator.Domain;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RssFeedAggregator.Managers
{
    public class SqlManager : ISqlManager<RssFeed>
    {
        protected ISqlRepository<RssFeed> Repository {get; private set;}

        public SqlManager(ISqlRepository<RssFeed> repository)
        {
            Repository = repository;
        }

        public async Task<RssFeed> Get(int id)
        {
            var feed = await Repository.GetByIdAsync(id);
            return feed;

        }
        public async Task<IEnumerable<RssFeed>> GetAll()
        {
            var feeds = await Repository.GetAllAsync();
            return feeds;
        }
        public async Task<RssFeed> Add(RssFeed model)
        {
            throw new NotImplementedException();
        }
        public async Task<RssFeed> Update(RssFeed model)
        {
            throw new NotImplementedException();
        }
        public async Task Delete(RssFeed model)
        {
            throw new NotImplementedException();
        }      
        public async Task<bool> IsAlive()
        {
            return true;
        }
    }
}