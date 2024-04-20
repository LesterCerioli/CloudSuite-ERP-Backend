using CloudSuite.Marketing.Commons.ValueObjects;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Marketing.Modules.Domain.Models
{
    public class User : Entity, IAggregateRoot
    {

        public User(string name, string email, Telephone telephone)
        {
            Name = name;
            Email = email;
            Telephone = telephone;
            Interactions = new List<UserInteraction>();
        }

        public string? Name { get; private set; }

        public string? Email { get; private set; }

        public Telephone Telephone { get; private set; }

        public ICollection<UserInteraction> Interactions { get; private set; }

        // Method to add a new interaction for the user
        public void AddInteraction(UserInteraction interaction)
        {
            Interactions.Add(interaction);
        }
    }
}
