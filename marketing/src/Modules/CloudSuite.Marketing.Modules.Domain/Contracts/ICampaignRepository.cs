using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Marketing.Modules.Domain.Models;

namespace CloudSuite.Marketing.Modules.Domain.Contracts
{
    public interface ICampaignRepository
    {
        Task<Campaign> GetByCampaignName(string campaignName);

        Task<Campaign> GetByStartDate(DateTime startDate);

        Task<Campaign> GetByEndDate(DateTime endDate);

        Task<IEnumerable<Campaign>> GetList();

        Task Add(Campaign campaign);

        void Update(Campaign campaign);

        void Remove(Campaign campaign);


    }
}
