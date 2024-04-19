using CloudSuite.Application.Handlers.Companies;
using CloudSuite.Application.ViewModels;
using CloudSuite.Modules.Commons.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Application.Services.Contracts
{
	public interface ICompanyAppService
	{
		Task<CompanyViewModel> GetByCnpj(Cnpj cnpj);

		Task<CompanyViewModel> GetByFantasyName(string fantasyName);

		Task<CompanyViewModel> GetBySocialName(string socialName);

		Task Save(CreateCompanyCommand commandCreate);
	}
}
