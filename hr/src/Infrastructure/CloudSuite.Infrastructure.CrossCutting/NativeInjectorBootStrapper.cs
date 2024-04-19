using CloudSuite.HR.Infrastructure.Context;
using CloudSuite.Modules.HR.Domain.Contracts;
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
            services.AddScoped<HRDbContext>();
            services.AddScoped<IEmployeeRepository>();
            //services.AddScoped<ILunchTimeExceededEventReposotory>();
            services.AddScoped<ITimeRecordRepository>();
            services.AddScoped<IWorkHourRecordRepository>();
            


            // Application
            //services.AddScoped<ICityAppService, CityAppService>();
            //services.AddScoped<IAddressAppService, AddressAppService>();
            //services.AddScoped<ICompanyAppService, CompanyAppService>();
            //services.AddScoped<ICountryAppService, CountryAppService>();
            //services.AddScoped<IDistrictAppService, DistrictAppService>();
            //services.AddScoped<IEmailAppService, EmailAppService>();
            //services.AddScoped<IMediaAppService, MediaAppService>();
            //services.AddScoped<IStateAppService, StateAppService>();
            //services.AddScoped<IUserAppService, UserAppService>();
            //services.AddScoped<IVendorAppService, VendorAppService>();
            //services.AddScoped<IPasswordAppService, PasswordAppService>();


        }
    }
}
