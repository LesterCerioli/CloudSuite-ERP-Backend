using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Marketing.Modules.Domain.Models
{
    public class SearchResult : Entity, IAggregateRoot
    {
        public SearchResult(string? searchQuery, int? position, string? pageUrl, 
        string? source, string wordKey)
        {
            SearchQuery = searchQuery;
            Position = position;
            PageUrl = pageUrl;
            Source = source;
            Wordkey = wordKey;
        }

        public string? Wordkey { get; private set; }
        
        public string? SearchQuery { get; private set; }

        public int? Position { get; private set; }

        public string? PageUrl { get; private set; }

        public string? Source { get; private set; }
    }
}
