using System;

namespace RssFeedAggregator.Domain
{
    public class RssFeedItem
    {
        public int Id {get;set;}
        
        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Description {get;set;}

        public string Url {get;set;}

        public bool IsImportant {get;set;}
    }
}