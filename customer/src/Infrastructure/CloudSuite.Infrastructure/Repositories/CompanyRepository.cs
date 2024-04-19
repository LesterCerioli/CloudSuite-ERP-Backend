using CloudSuite.Infrastructure.Context;
using CloudSuite.Modules.Commons.ValueObjects;
using CloudSuite.Modules.Domain.Contracts;
using CloudSuite.Modules.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Repositories
{
	public class CompanyRepository : ICompanyRepository
	{

		protected readonly CustomerDbContext Db;
		protected readonly DbSet<Company> DbSet;
		
		public CompanyRepository(CustomerDbContext context)
		{
			Db = context;
			DbSet = context.Companies;
		}

		public async Task Add(Company company)
		{
			await Task.Run(() =>
			{
				Db.Add(company);
			});
		}

		public async Task<Company> GetByCnpj(Cnpj cnpj)
		{
			return await DbSet.FirstOrDefaultAsync(c => c.Cnpj == cnpj);
		}

		public async Task<Company> GetByFantasyName(string fantasyName)
		{
			return await DbSet.FirstOrDefaultAsync(c => c.FantasyName == fantasyName);
		}

		public async Task<Company> GetBySocialName(string socialName)
		{
			return await DbSet.FirstOrDefaultAsync(c => c.SocialName == socialName);
		}

		public async Task<IEnumerable<Company>> GetList()
		{
			return DbSet.ToList();
		}

		public void Remove(Company company)
		{
			Db.Remove(company);
		}

		public void Update(Company company)
		{
			Db.Update(company);
		}

		public void Dispose() {
			Db.Dispose();
		}
	}
}
