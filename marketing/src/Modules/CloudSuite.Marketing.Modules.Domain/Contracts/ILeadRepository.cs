using CloudSuite.Marketing.Modules.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Marketing.Modules.Domain.Contracts
{
    public interface ILeadRepository
    {
        Task<Lead> GetByName(string name);

        Task<Lead> GetbyEmail(string email);

        Task<Lead> GetByCompany(string companyName);

        Task<IEnumerable<Lead>> GetList();

        Task Add(Lead lead);

        void Update(Lead lead);

        void Remove(Lead lead);
    }
}
