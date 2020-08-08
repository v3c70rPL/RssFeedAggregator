using System.Linq;
using System;
using System.Collections.Generic;
using RssFeedAggregator.Interfaces;
using RssFeedAggregator.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace RssFeedAggregator.Repositories
{
    public class SqlRepository<T> : ISqlRepository<T>
    where T : RssFeed
    {
        protected RssFeedAggregatorDbContext DbContext {get; private set;}

        public SqlRepository(RssFeedAggregatorDbContext context)
        {
            DbContext = context;
        }   

        public T Add(T model)
        {
            var result = DbContext.Add(model);
            return result.Entity;
        }

        public T Update(T model)
        {
            foreach(var item in model.Items)
            {
                if(item.IsDeleted)
                {
                    DbContext.Remove(item);
                }
            }

            var result = DbContext.Update(model);

            return result.Entity;
          
        }

        public T Delete(int id)
        {
            var model = DbContext.RssFeeds.Where(p => p.Id == id).Include(p => p.Items).FirstOrDefault();
            foreach(var item in model.Items)
            {
                // TODO: add error handling
                DbContext.Remove(item);
            }

            // TODO: add error handling
            DbContext.Remove(model);
            
            return model as T;
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var query = DbContext.RssFeeds.Where(p => p.Id == id).Include(i => i.Items);
            return await query.FirstOrDefaultAsync(p => p.Id == id) as T;
        }

        // TODO: refactor so there is no additional reiteration on the list
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var queryResult = await DbContext.RssFeeds.Include(p => p.Items).ToListAsync();
            var result = new List<T>();
            
            foreach(var feed in queryResult)
            {
                result.Add(feed as T);
            }

            return result;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await DbContext.SaveChangesAsync();
        }

    }
}