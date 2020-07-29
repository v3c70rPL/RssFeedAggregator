using Microsoft.EntityFrameworkCore;
using RssFeedAggregator.Domain;

namespace RssFeedAggregator
{
    public class RssFeedAggregatorDbContext : DbContext
    {
        public RssFeedAggregatorDbContext(DbContextOptions<RssFeedAggregatorDbContext> options) : base (options)
        {
        }

        public DbSet<RssFeed> RssFeeds {get;set;}

        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     builder.Entity<RssFeed>()
        //         .HasOne(p => p.Items);
        // }

    }
}