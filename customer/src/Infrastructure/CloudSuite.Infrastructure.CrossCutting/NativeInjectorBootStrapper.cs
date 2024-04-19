using CloudSuite.Application.Services.Contracts;
using CloudSuite.Application.Services.Implementations;
using CloudSuite.Infrastructure.Context;
using CloudSuite.Modules.Domain.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.CrossCutting
{
	public class NativeInjectorBootStrapper
	{
		public static void RegisterServices(IServiceCollection services)
		{
			services.AddScoped<ICompanyRepository>();
			services.AddScoped<CustomerDbContext>();

			services.AddScoped<ICompanyAppService, CompanyAppService>();
		}
	}
}
