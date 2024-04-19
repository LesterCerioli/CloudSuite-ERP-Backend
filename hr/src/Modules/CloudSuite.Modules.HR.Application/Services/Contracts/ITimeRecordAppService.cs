using CloudSuite.Modules.HR.Application.ViewModels;
using CloudSuite.Modules.HR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.HR.Application.Services.Contracts
{
    public interface ITimeRecordAppService
    {
        Task<TimeRecordViewModel> GetByEntryTime(DateTime? entryTime);

        Task<TimeRecordViewModel> GetByExitTime(DateTime? exitTime);

        //Task SaveAsync(CreateTimeRecordCommand commandcreate)
    }
}
