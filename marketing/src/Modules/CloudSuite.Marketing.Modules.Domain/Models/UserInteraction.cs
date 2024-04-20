using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Marketing.Modules.Domain.Models
{
    public class UserInteraction : Entity, IAggregateRoot
    {
        private readonly List<User> _users;

        public UserInteraction(int userId, string pageUrl, string action, string outcome, string deviceType, string referringUrl)
        {
            _users = new List<User>();
            PageUrl = pageUrl;
            Timestamp = DateTime.Now;
            Action = action;
            Outcome = outcome;
            DeviceType = deviceType;
            ReferringUrl = referringUrl;
        }

        public User User { get; private set; }

        public IReadOnlyCollection<User> User => _users.AsReadOnly();

        
        public string? PageUrl { get; private set; }

        public DateTimeOffset? Timestamp { get; private set; }

        public string? Action { get; private set; }

        public string? Outcome { get; private set; }

        public string? DeviceType { get; private set; }

        public string? ReferringUrl { get; private set; }
    }
}
