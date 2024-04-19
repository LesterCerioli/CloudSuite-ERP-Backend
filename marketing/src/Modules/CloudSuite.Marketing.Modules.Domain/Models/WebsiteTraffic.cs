using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Marketing.Modules.Domain.Models
{
    public class WebsiteTraffic : Entity, IAggregateRoot
    {
        public WebsiteTraffic(string pageUrl, string source, string deviceType)
        {
            PageUrl = pageUrl;
            Source = source;
            DeviceType = deviceType;
        }

        public string PageUrl { get; private set; }

        public string Source { get; private set; }

        public string DeviceType { get; private set; }
    }
}
