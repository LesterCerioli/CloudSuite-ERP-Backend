using CloudSuite.Marketing.Commons.ValueObjects;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Marketing.Modules.Domain.Models
{
    public class Lead : Entity, IAggregateRoot
    {
        public Lead(string? name, string? email, Telephone telephone, string? company, 
            string? source, string? status, string? interactionHistory)
        {
            Name = name;
            Email = email;
            Telephone = telephone;
            Company = company;
            Source = source;
            Status = status;
            InteractionHistory = interactionHistory;
        }

        public string? Name { get; private set; }
        
        public string? Email { get; private set; }
        
        public Telephone Telephone { get; private set; }
        
        public string? Company { get; private set; }
        
        public string? Source { get; private set; }
        
        public string? Status { get; private set; }
        
        public string? InteractionHistory { get; private set; }
    }
}
