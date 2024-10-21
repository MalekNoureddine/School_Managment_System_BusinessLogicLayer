using FluentValidation;
using School_Managment_System1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Validations
{
    public class ExamValidator : AbstractValidator<Exam>
    {
        public ExamValidator()
        {
            RuleFor(e => e.ExamName)
                .NotEmpty().WithMessage("Exam name is required.")
                .MaximumLength(100).WithMessage("Exam name must not exceed 100 characters.");

            RuleFor(e => e.ClassSubjectId)
                .GreaterThan(0).WithMessage("Class Subject ID must be greater than zero.");

            RuleFor(e => e.DateScheduled)
                .NotNull().WithMessage("Exam date is required.")
                .Must(date => date >= DateOnly.FromDateTime(DateTime.Today)).WithMessage("Exam date cannot be in the past.");

            RuleFor(e => e.Trimester)
                .InclusiveBetween(1, 3).WithMessage("Trimester must be between 1 and 3.");
        }
    }
}
