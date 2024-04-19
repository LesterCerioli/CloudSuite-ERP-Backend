using CloudSuite.Commons.ValueObjects;
using CloudSuite.Modules.HR.Application.Handlers.Employees.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeEntity = CloudSuite.Modules.HR.Domain.Models.Employee;

namespace CloudSuite.Modules.HR.Application.Handlers.Employees
{
    
    public class CreateEmployeeCommand : IRequest <CreateEmployeeResponse>
	{
        internal readonly object Id;

        public Guid id { get;private set; }

        public string? Fullname { get;  set; }

        public string? EmailAddress { get;  set; }

        public string? Cpf { get;  set; }

        public CreateEmployeeCommand(Guid id, string? fullname, string? emailAddress, string? cpf)
        {
            id = Guid.NewGuid();
            Fullname = fullname;
            EmailAddress = emailAddress;
            Cpf = cpf;
        }
        public EmployeeEntity GetEntity()

        {
            return new EmployeeEntity(
                this.Fullname,
                this.EmailAddress,
                new Cpf (this.Cpf)
             ) ; 
        }

    }
}
