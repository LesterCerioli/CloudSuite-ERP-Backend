using CloudSuite.Modules.HR.Application.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.HR.Application.Handlers.WorkHourRecord.Requests
{
    internal class CheckWorkTimeRecordByEmployeesRequest : Response
    {
        public CheckWorkTimeRecordByEmployeesRequest(Guid id, string? employee)
        {
            Id = id;
            Employee = employee;
        }

        public Guid Id { get; set; }

        public string? Employee { get; private set; }

     
    }
}
