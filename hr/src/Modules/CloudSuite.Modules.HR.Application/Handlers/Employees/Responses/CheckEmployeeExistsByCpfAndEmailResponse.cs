using CloudSuite.Modules.HR.Application.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace CloudSuite.Modules.HR.Application.Handlers.Employees.Responses
{
	public class CheckEmployeeExistsByCpfAndEmailResponse : Response
	{
        public Guid RequestId { get; private set; }
        public bool Exists { get; set; }

        public CheckEmployeeExistsByCpfAndEmailResponse(Guid requestId, bool exists, ValidationResult result)
        {
            RequestId = requestId;
            Exists = exists;
            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }

        public CheckEmployeeExistsByCpfAndEmailResponse(Guid requestId, string falseValidation)
        {
            RequestId = requestId;
            Exists = false;
            this.AddError(falseValidation);
        }
    }
}

