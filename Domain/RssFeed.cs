using System.Collections.Generic;

namespace RssFeedAggregator.Domain
{
    public class RssFeed : ModelBase
    {
        public string Title {get;set;}

        public string Description {get;set;}

        public IList<RssFeedItem> Items {get;set;}
    }
}