using CloudSuite.Marketing.Modules.Domain.Models;

namespace CloudSuite.Marketing.Modules.Domain.Contracts
{
    public interface IUserInteractionRepository
    {
        Task<UserInteraction> GetBypageurl(string pageUrl);

        Task<UserInteraction> GetByTimestamp(DateTime timestamp);

        Task<UserInteraction> GetByDevice(string deviceType);

        Task<IEnumerable<UserInteraction>> GetList();

        Task Add(UserInteraction userInteraction);

        void Update(UserInteraction userInteraction);

        void Remove(UserInteraction userInteraction);
    }
}