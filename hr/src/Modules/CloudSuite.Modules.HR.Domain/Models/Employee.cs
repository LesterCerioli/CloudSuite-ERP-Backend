using CloudSuite.Commons.ValueObjects;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.HR.Domain.Models
{
	public class Employee : Entity, IAggregateRoot
	{
		public Employee(string? fullname, string? emailAddress, Cpf cpf)
		{
			Fullname = fullname;
			EmailAddress = emailAddress;
			Cpf = cpf;
		}

		public string? Fullname { get; private set; }

        public string? EmailAddress { get; private set; }

        public Cpf Cpf { get; private set; }
    }
}
