using CloudSuite.Modules.HR.Application.Core;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.HR.Application.Handlers.TimeRecord.Responses
{
    public class CreateTimeRecordResponse : Response
    {
        public Guid RequestId { get; private set; }

        public CreateTimeRecordResponse(Guid requestId, ValidationResult result)
        {
            RequestId = requestId;

            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }

        public CreateTimeRecordResponse(Guid requestId, string failValidation)
        {
            RequestId = requestId;

            this.AddError(failValidation);
        }
    }  
}
