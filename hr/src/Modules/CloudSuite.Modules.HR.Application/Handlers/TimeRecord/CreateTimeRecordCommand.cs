using CloudSuite.Commons.ValueObjects;
using CloudSuite.Modules.HR.Application.Handlers.TimeRecord.Responses;
using CloudSuite.Modules.HR.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeRecordEntity = CloudSuite.Modules.HR.Domain.Models.TimeRecord;

namespace CloudSuite.Modules.HR.Application.Handlers.TimeRecord
{
    public class CreateTimeRecordCommand : IRequest<CreateTimeRecordResponse>
    {


        public Guid id { get; private set; }

        public DateTime EntryTime { get;  set; }

        public DateTime? ExitTime { get;  set; }

        public DateTime? LunchEntryTime { get;  set; }

        public DateTime? LunchReturnTime { get;  set; }

        public DateTime? LunchExitTime { get;  set; }

        public string? Employee { get; set; }
        

        public CreateTimeRecordCommand()
        {
            id = Guid.NewGuid();
        }
        public TimeRecordEntity GetEntity()
        {
            return new TimeRecordEntity(
               this.EntryTime,
               this.ExitTime.Value,
               this.LunchEntryTime.Value,
               this.LunchReturnTime.Value,
               this.Employee
            );
        }

    }
}
