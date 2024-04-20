using CloudSuite.Marketing.Commons.Enums;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CloudSuite.Marketing.Modules.Domain.Models
{
    public class GoogleAnalyticsIntegration : Entity, IAggregateRoot
    {
        public GoogleAnalyticsIntegration(string? apiKey, DateTimeOffset? dateRangeStart, DateTimeOffset? dateRangeEnd, string? applicationUrl, int? visitNumber, string? county, string? stateOrProvince, string? cityName, Device deviceEnum)
        {
            ApiKey = apiKey;
            DateRangeStart = DateTime.Now;
            DateRangeEnd = DateTime.Now;
            ApplicationUrl = applicationUrl;
            VisitNumber = visitNumber;
            County = county;
            StateOrProvince = stateOrProvince;
            CityName = cityName;
            DeviceEnum = deviceEnum;
        }

        public string? ApiKey { get; private set; }

        
        public DateTimeOffset? DateRangeStart { get; private set; }

        public DateTimeOffset? DateRangeEnd { get; private set; }

        public string? ApplicationUrl { get; private set; }

        public int? VisitNumber { get; private set; }

        public string? County { get; private set; }

        public string? StateOrProvince { get; private set; }

        public string? CityName { get; private set; }

        public Device DeviceEnum { get; private set; }
    }
}
