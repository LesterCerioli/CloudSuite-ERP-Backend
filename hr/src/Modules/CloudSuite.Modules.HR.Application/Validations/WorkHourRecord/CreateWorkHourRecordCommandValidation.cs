using CloudSuite.Modules.HR.Application.Handlers.TimeRecord;
using CloudSuite.Modules.HR.Application.Handlers.WorkHourRecord;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.HR.Application.Validations.WorkHourRecord
{
    public class CreateWorkHourRecordCommandValidation : AbstractValidator<CreateWorkHourRecordCommand>
    {
        public CreateWorkHourRecordCommandValidation()
        {
            RuleFor(a => a.Month)
                .NotEmpty()
                .WithMessage("Completing the Month is mandatory");

            RuleFor(a => a.Month)
                .InclusiveBetween(1, 12)
                .WithMessage("Month must be between 1 and 12");

            RuleFor(a => a.Year)
                .NotEmpty()
                .WithMessage("Completing the Year is mandatory");

            RuleFor(a => a.Year)
                .GreaterThan(1900)
                .WithMessage("Year must be greater than 1900");

            RuleFor(a => a.WorkedHours)
                .NotEmpty()
                .WithMessage("Completing the WorkedHours is mandatory");

            RuleFor(a => a.WorkedHours)
                .GreaterThanOrEqualTo(0)
                .WithMessage("WorkedHours must be a positive value");

        }
    }
}
