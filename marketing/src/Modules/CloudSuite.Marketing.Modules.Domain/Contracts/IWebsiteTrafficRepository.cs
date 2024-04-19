using CloudSuite.Marketing.Modules.Domain.Models;

namespace CloudSuite.Marketing.Modules.Domain.Contracts
{
    public interface IWebsiteTrafficRepository
    {
        Task<WebsiteTraffic> GetByPageUrl(string pageUrl);

        Task<WebsiteTraffic> GetByDeviceType(string deviceType);

        Task<IEnumerable<WebsiteTraffic>> GetList();

        Task Add(WebsiteTraffic websiteTraffic);

        void Update(WebsiteTraffic websiteTraffic);

        void Remove(WebsiteTraffic websiteTraffic);
    }
}