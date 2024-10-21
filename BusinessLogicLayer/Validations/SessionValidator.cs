using FluentValidation;
using School_Managment_System1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Validations
{
    public class SessionValidator : AbstractValidator<Session>
    {
        public SessionValidator()
        {
            RuleFor(s => s.SessionId)
                .GreaterThan(0).WithMessage("Session ID must be greater than zero.");

            RuleFor(s => s.ClassSubjectId)
                .GreaterThan(0).WithMessage("Class Subject ID must be greater than zero.");

            RuleFor(s => s.Date)
                .NotEmpty().WithMessage("Session date is required.")
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today)).WithMessage("Session date cannot be in the future.");

            RuleFor(s => s.StartTime)
                .NotEmpty().WithMessage("Start time is required.");

            RuleFor(s => s.EndTime)
                .NotEmpty().WithMessage("End time is required.")
                .GreaterThan(s => s.StartTime).WithMessage("End time must be later than start time.");
        }
    }
}
