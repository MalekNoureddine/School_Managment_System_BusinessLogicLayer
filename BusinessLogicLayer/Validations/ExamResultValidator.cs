using FluentValidation;
using School_Managment_System1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Validations
{
    internal class ExamResultValidator : AbstractValidator<ExamResult>
    {
        public ExamResultValidator()
        {
            RuleFor(er => er.StudentId)
                .GreaterThan(0).WithMessage("Student ID must be greater than zero.");

            RuleFor(er => er.ExamId)
                .GreaterThan(0).WithMessage("Exam ID must be greater than zero.");

            RuleFor(er => er.Score)
                .InclusiveBetween(0, 20).WithMessage("Score must be between 0 and 20.")
                .When(er => er.Score.HasValue); // Only validate if Score has a value

            RuleFor(er => er.DateTaken)
                .NotNull().WithMessage("Date taken is required.")
                .Must(date => date <= DateOnly.FromDateTime(DateTime.Today)).WithMessage("Date taken cannot be in the future.");

            RuleFor(er => er.Note)
                .MaximumLength(250).WithMessage("Note must not exceed 250 characters.")
                .When(er => !string.IsNullOrWhiteSpace(er.Note)); // Validate only if Note is not null or empty
        }
    }
}
