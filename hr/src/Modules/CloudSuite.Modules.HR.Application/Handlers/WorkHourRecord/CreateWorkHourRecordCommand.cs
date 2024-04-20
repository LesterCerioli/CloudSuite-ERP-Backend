using CloudSuite.Modules.HR.Application.Handlers.WorkHourRecord.Responses;
using CloudSuite.Modules.HR.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkHourRecordEntity = CloudSuite.Modules.HR.Domain.Models.WorkHourRecord;

namespace CloudSuite.Modules.HR.Application.Handlers.WorkHourRecord
{
    public class CreateWorkHourRecordCommand : IRequest<CreateWorkHourRecordResponse>
    {
        public Guid id { get; private set; }

        public int? Month { get;  set; }

        public int? Year { get;  set; }

        public double? WorkedHours { get;  set; }

        public string? Employee { get;  set; }

   

        public CreateWorkHourRecordCommand(Guid id, int? month, int? year, double? workedHours, string? employee)
        {
            id = Guid.NewGuid();
            Month = month;
            Year = year;
            WorkedHours = workedHours;
            Employee = employee;
        }

        public WorkHourRecordEntity GetEntity()
        {
            return new WorkHourRecordEntity(
               this.Month, 
               this.Year, 
               this.WorkedHours, 
               this.Employee
        
            );
        }

    }
}
