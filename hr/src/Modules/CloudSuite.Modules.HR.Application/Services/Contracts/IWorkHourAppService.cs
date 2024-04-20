using CloudSuite.Modules.HR.Application.ViewModels;
using CloudSuite.Modules.HR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.HR.Application.Services.Contracts
{
    public interface IWorkHourAppService
    {
        Task<WorkHourViewmodel> GetByMonth(int? month);

        Task<WorkHourViewmodel> GetByYear(int? year);

        Task<WorkHourViewmodel> GetByWorkedHours(double? workHour);

        //Task SaveAsync(CreateWorkHourCommand createCommand);
    }
}
