using CloudSuite.Modules.HR.Application.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace CloudSuite.Modules.HR.Application.Handlers.Employees.Responses
{
    public class CreateEmployeeResponse : Response
    {
        public Guid RequestId { get; private set; }

        public CreateEmployeeResponse(Guid requestId, ValidationResult result) 
        {
            RequestId = requestId;
 
            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }

        public CreateEmployeeResponse(Guid requestId, string failValidation)
        {
            RequestId = requestId;
       
            this.AddError(failValidation);
        }
    }
}
