using CloudSuite.Marketing.Commons.ValueObjects;
using CloudSuite.Marketing.Modules.Domain.Models;

namespace CloudSuite.Marketing.Modules.Domain.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetByName(string name);

        Task<User> GetByTelephone(Telephone telephone);

        Task<User> GetByEmail(string email);

        Task<IEnumerable<User>> GetList();

        Task Add(User user);

        void Update(User user);

        void Remove(User user);
    }
}