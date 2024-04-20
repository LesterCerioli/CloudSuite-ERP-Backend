using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CloudSuite.Marketing.Modules.Domain.Models
{
    public class Campaign : Entity, IAggregateRoot
    {

        protected Campaign() { } // Required by Entity Framework Core

        public Campaign(string campaignname, string description, DateTime startDate, DateTime endDate, decimal budget)
        {
            CampaignName = campaignname;
            Description = description;
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            Budget = budget;
            Channels = new List<string>();
            Objectives = new List<string>();
            PerformanceMetrics = new Dictionary<string, int>();
        }

        public string? CampaignName { get; private set; }

        public string? Description { get; private set; }

        public DateTimeOffset? StartDate { get; private set; }

        public DateTime? EndDate { get; private set; }

        public decimal? Budget { get; private set; }

        public List<string> Channels { get; private set; }

        public List<string> Objectives { get; private set; }

        public Dictionary<string, int> PerformanceMetrics { get; private set; }
    }
}
