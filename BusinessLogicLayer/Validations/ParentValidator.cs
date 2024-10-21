using FluentValidation;
using School_Managment_System1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Validations
{
    public class ParentValidator : AbstractValidator<Parent>
    {
        public ParentValidator()
        {
            RuleFor(p => p.ParentId)
                .GreaterThan(0).WithMessage("Parent ID must be greater than zero.");

            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name must not exceed 50 characters.");

            RuleFor(p => p.PhoneNumber)
                .Matches(@"^\+?\d{10,15}$").WithMessage("Phone number must be between 10 and 15 digits and may start with a '+'.");

            RuleFor(p => p.Email)
                .EmailAddress().WithMessage("Invalid email format.")
                .When(p => !string.IsNullOrEmpty(p.Email)); // Validate only if Email is provided
        }
    }
}
