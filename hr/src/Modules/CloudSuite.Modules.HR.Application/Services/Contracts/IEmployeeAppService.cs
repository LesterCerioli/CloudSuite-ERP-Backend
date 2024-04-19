using CloudSuite.Commons.ValueObjects;
using CloudSuite.Modules.HR.Application.Handlers.Employees;
using CloudSuite.Modules.HR.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.HR.Application.Services.Contracts
{
    public interface IEmployeeAppService
    {
        Task<EmployeeViewModel> GetByCnpj(Cpf cpf);

        Task<EmployeeViewModel> GetByFullname(string fullname);

        Task SaveAsync(CreateEmployeeCommand commandCreate);
    }
}
