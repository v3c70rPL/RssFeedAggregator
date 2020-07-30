using System.Linq;
using System;
using System.Collections.Generic;
using RssFeedAggregator.Interfaces;
using RssFeedAggregator.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace RssFeedAggregator.Repositories
{
    // TODO: why <T> is applied to interface ?
    public class SqlRepository : ISqlRepository<RssFeed>
    {
        protected RssFeedAggregatorDbContext DbContext {get; private set;}

        public SqlRepository(RssFeedAggregatorDbContext context)
        {
            DbContext = context;
        }   

        public RssFeed Add(RssFeed model)
        {
            throw new NotImplementedException();
        }

        public RssFeed Update(RssFeed model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public RssFeed GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<RssFeed> GetByIdAsync(int id)
        {
            var query = DbContext.RssFeeds.Where(p => p.Id == id).Include(i => i.Items);
            return await query.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<RssFeed>> GetAllAsync()
        {
            var query = DbContext.RssFeeds.Include(i => i.Items);
            return await query.ToListAsync();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

    }
}