using FluentValidation;
using School_Managment_System1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Validations
{
    public class TeacherValidator : AbstractValidator<Teacher>
    {
        public TeacherValidator()
        {
            RuleFor(t => t.TeacherId)
                .GreaterThan(0).WithMessage("Teacher ID must be greater than zero.");

            RuleFor(t => t.FirstName)
                .NotEmpty().WithMessage("First Name is required.")
                .Length(2, 50).WithMessage("First Name must be between 2 and 50 characters.");

            RuleFor(t => t.LastName)
                .NotEmpty().WithMessage("Last Name is required.")
                .Length(2, 50).WithMessage("Last Name must be between 2 and 50 characters.");

            RuleFor(t => t.SubjectSpecialization)
                .Length(0, 100).WithMessage("Subject Specialization must be less than or equal to 100 characters.")
                .When(t => !string.IsNullOrEmpty(t.SubjectSpecialization)); // Allow null/empty but limit length if provided

            RuleFor(p => p.PhoneNumber)
                .Matches(@"^\+?\d{10,15}$").WithMessage("Phone number must be between 10 and 15 digits and may start with a '+'.");

            RuleFor(t => t.Email)
                .EmailAddress().WithMessage("Email must be a valid email address.")
                .When(t => !string.IsNullOrEmpty(t.Email)); // Allow null/empty but validate format if provided

            RuleFor(t => t.UserId)
                .GreaterThan(0).WithMessage("User ID must be greater than zero.")
                .When(t => t.UserId.HasValue); // Validate if UserId is provided
        }
    }
}
