using RssFeedAggregator.Interfaces;
using RssFeedAggregator.Domain;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RssFeedAggregator.Managers
{
    public class SqlManager<T> : ISqlManager<T>
    where T : RssFeed
    {
        protected ISqlRepository<T> Repository {get; private set;}

        public SqlManager(ISqlRepository<T> repository)
        {
            Repository = repository;
        }

        public async Task<T> Get(int id)
        {
            var feed = await Repository.GetByIdAsync(id);
            return feed;

        }
        public async Task<IEnumerable<T>> GetAll()
        {
            var feeds = await Repository.GetAllAsync();
            return feeds;
        }
        public async Task<T> Add(T model)
        {
            var result = Repository.Add(model);
            await Repository.SaveChangesAsync();

            return result; 
        }
        public async Task<T> Update(T model)
        {
            var result = Repository.Update(model);
            await Repository.SaveChangesAsync();

            return result;
        }
        public async Task<T> Delete(int id)
        {
            var result = Repository.Delete(id);
            await Repository.SaveChangesAsync();

            return result;
        }      
        public bool IsAlive()
        {
            return true;
        }
    }
}