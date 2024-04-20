
using CloudSuite.Modules.HR.Application.Handlers.TimeRecord;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.HR.Application.Validations.TimeRecord
{
    public class CreateTimeRecordCommandValidation : AbstractValidator<CreateTimeRecordCommand>
                                                    
    {
        public CreateTimeRecordCommandValidation()
        {

            RuleFor(a => a.EntryTime)
                .NotEmpty()
                .WithMessage("Completing the EntryTime is mandatory");

            RuleFor(a => a.ExitTime)
                .NotEmpty()
                .WithMessage("Completing the ExitTime is mandatory")
                .GreaterThan(a => a.EntryTime)
                .WithMessage("Exit time must be after Entry time");

            RuleFor(a => a.EntryTime)
                .Must((command, entryTime) => entryTime < command.ExitTime)
                .WithMessage("Entry time must be before Exit time");

            RuleFor(a => a.LunchEntryTime)
                .NotEmpty()
                .WithMessage("Completing the LunchEntryTime is mandatory")
                .GreaterThanOrEqualTo(a => a.EntryTime)
                .WithMessage("Lunch entry time must be after or equal to Entry time")
                .LessThan(a => a.LunchReturnTime)
                .WithMessage("Lunch entry time must be before Lunch return time");

            RuleFor(a => a.LunchReturnTime)
                .NotEmpty()
                .WithMessage("Completing the LunchReturnTime is mandatory")
                .GreaterThan(a => a.LunchEntryTime)
                .WithMessage("Lunch return time must be after Lunch entry time")
                .LessThanOrEqualTo(a => a.ExitTime)
                .WithMessage("Lunch return time must be before or equal to Exit time");

            RuleFor(a => a.LunchExitTime)
                .NotEmpty()
                .WithMessage("Completing the LunchExitTime is mandatory")
                .GreaterThan(a => a.LunchReturnTime)
                .WithMessage("Lunch exit time must be after Lunch return time")
                .LessThanOrEqualTo(a => a.ExitTime)
                .WithMessage("Lunch exit time must be before or equal to Exit time");

        }

    }
}

