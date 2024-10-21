using FluentValidation;
using School_Managment_System1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Validations
{
    internal class ClassScheduleValidator : AbstractValidator<ClassSchedule>
    {
        public ClassScheduleValidator()
        {
            RuleFor(cs => cs.ClassName)
                .NotEmpty().WithMessage("Class name is required.")
                .MaximumLength(100).WithMessage("Class name must not exceed 100 characters.");

            RuleFor(cs => cs.SubjectID)
                .GreaterThan(0).WithMessage("Subject ID must be greater than zero.");

            RuleFor(cs => cs.DayOfWeek)
                .NotEmpty().WithMessage("Day of the week is required.")
                .Matches(@"^(Sunday|Monday|Tuesday|Wednesday|Thursday|Friday|Saturday)$")
                .WithMessage("Day of the week must be a valid day (Sunday to Saturday).");

            RuleFor(cs => cs.StartTime)
                .LessThan(cs => cs.EndTime).WithMessage("Start time must be earlier than end time.");

            RuleFor(cs => cs.EndTime)
                .GreaterThan(cs => cs.StartTime).WithMessage("End time must be later than start time.");

            RuleFor(c => c.SubjectID)
                .GreaterThan(0).WithMessage("Subject ID must be greater than zero.");
        }
    }
}
