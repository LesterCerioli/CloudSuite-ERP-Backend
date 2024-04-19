using CloudSuite.Modules.HR.Application.Core;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.HR.Application.Handlers.WorkHourRecord.Responses
{
    public class CreateWorkHourRecordResponse : Response
    {
        public Guid RequestId { get; private set; }

        public CreateWorkHourRecordResponse(Guid requestId, ValidationResult result)
        {
            RequestId = requestId;

            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }

        public CreateWorkHourRecordResponse(Guid requestId, string failValidation)
        {
            RequestId = requestId;

            this.AddError(failValidation);
        }
    }
}
