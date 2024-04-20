using CloudSuite.Marketing.Modules.Domain.Models;

namespace CloudSuite.Marketing.Modules.Domain.Contracts
{
    public interface IGoogleAnalyticsIntegrationRepository
    {
        Task<GoogleAnalyticsIntegration> GetByDateRangeStart(DateTime dateRangeStart);

        Task<GoogleAnalyticsIntegration> GetByEnddate(DateTime dateRangeEnd);

        Task<GoogleAnalyticsIntegration> GetByApplicationUrl(string applicationUrl);

        Task<IEnumerable<GoogleAnalyticsIntegration>> GetList();
        
        Task Add(GoogleAnalyticsIntegration googleAnalyticsIntegration);

        void Update(GoogleAnalyticsIntegration googleAnalyticsIntegration);

        void Remove(GoogleAnalyticsIntegration googleAnalyticsIntegration);
    }
}