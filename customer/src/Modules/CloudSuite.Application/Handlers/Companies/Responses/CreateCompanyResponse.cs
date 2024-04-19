using CloudSuite.Application.Core;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Application.Handlers.Companies.Responses
{
    public class CreateCompanyResponse : Response
    {
        public Guid RequestId { get; private set; }

        public CreateCompanyResponse(Guid requestid, ValidationResult result)
        {
            RequestId = requestid;
            foreach(var item in result.Errors) {
                this.AddError(item.ErrorMessage);
            }
        }

        public CreateCompanyResponse(Guid requestid, string validationFailure)
        {
            RequestId = requestid;
            this.AddError(validationFailure);
        }
    }
}
