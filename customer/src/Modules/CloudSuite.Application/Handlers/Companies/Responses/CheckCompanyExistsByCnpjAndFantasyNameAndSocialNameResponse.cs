using CloudSuite.Application.Core;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Application.Handlers.Companies.Responses
{
    public class CheckCompanyExistsByCnpjAndFantasyNameAndSocialNameResponse : Response
    {
        public Guid RequestId {  get; private set; }
        public bool Exists {  get; set; }

        public CheckCompanyExistsByCnpjAndFantasyNameAndSocialNameResponse(Guid requestId, bool exists, ValidationResult result)
        {
            RequestId = requestId;
            Exists = exists;
            foreach(var item in result.Errors) {
                this.AddError(item.ErrorMessage);
            }
        }

        public CheckCompanyExistsByCnpjAndFantasyNameAndSocialNameResponse(Guid requestId, string validationFailure)
        {
            RequestId = requestId;
            Exists = false;
            this.AddError(validationFailure);
        }
    }
}
