using CloudSuite.Commons.ValueObjects;
using CloudSuite.Modules.HR.Application.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.HR.Application.Handlers.Employees.Requests
{
	public class CheckEmployeeExistsByCpfAndEmailRequest : Response
	{
        public Guid Id { get; set; }

        public string? Cpf { get; private set; }

        public string? EmailAddress { get;  set; }


        public CheckEmployeeExistsByCpfAndEmailRequest(Guid id, string? cpf, string? emailAddress)
        {
            Id = id;
            Cpf = cpf;
            EmailAddress = emailAddress;
        }
    }
}
