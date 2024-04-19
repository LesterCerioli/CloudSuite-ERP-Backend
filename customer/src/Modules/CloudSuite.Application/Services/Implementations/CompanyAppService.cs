using AutoMapper;
using CloudSuite.Application.Handlers.Companies;
using CloudSuite.Application.Services.Contracts;
using CloudSuite.Application.ViewModels;
using CloudSuite.Modules.Commons.ValueObjects;
using CloudSuite.Modules.Domain.Contracts;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Application.Services.Implementations
{
	public class CompanyAppService : ICompanyAppService
	{
		private readonly ICompanyRepository _companyRepository;
		private readonly IMapper _mapper;
		private readonly IMediatorHandler _mediator;

		public CompanyAppService(
			ICompanyRepository companyRepository,
			IMapper mapper,
			IMediatorHandler mediator
			) 
		{
			_companyRepository = companyRepository;
			_mapper = mapper;
			_mediator = mediator;
		}
		public async Task<CompanyViewModel> GetByCnpj(Cnpj cnpj)
		{
			return _mapper.Map<CompanyViewModel>(await _companyRepository.GetByCnpj(cnpj));
		}

		public async Task<CompanyViewModel> GetByFantasyName(string fantasyName)
		{
			return _mapper.Map<CompanyViewModel>(await _companyRepository.GetByFantasyName(fantasyName));
		}

		public async Task<CompanyViewModel> GetBySocialName(string socialName)
		{
			return _mapper.Map<CompanyViewModel>(await _companyRepository.GetBySocialName(socialName));
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}

		public async Task Save(CreateCompanyCommand commandCreate)
		{
			await _companyRepository.Add(commandCreate.GetEntity());
		}
	}
}
