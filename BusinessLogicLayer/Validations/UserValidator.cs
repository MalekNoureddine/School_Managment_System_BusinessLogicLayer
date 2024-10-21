using FluentValidation;
using School_Managment_System1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.UserId)
                .GreaterThan(0).WithMessage("User ID must be greater than zero.");

            RuleFor(u => u.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(3, 20).WithMessage("Username must be between 3 and 20 characters.");

            RuleFor(u => u.PasswordHash)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

            RuleFor(u => u.Role)
                .NotEmpty().WithMessage("Role is required.")
                .Must(BeAValidRole).WithMessage("Role must be either 'Admin' Or 'Teacher'.");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email format is not valid.");

            RuleFor(u => u.FirstName)
                .NotEmpty().WithMessage("First Name is required.")
                .Length(2, 50).WithMessage("First Name must be between 2 and 50 characters.");

            RuleFor(u => u.LastName)
                .NotEmpty().WithMessage("Last Name is required.")
                .Length(2, 50).WithMessage("Last Name must be between 2 and 50 characters.");

            RuleFor(u => u.CreatedAt)
                .NotNull().WithMessage("Created At date is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Created At date cannot be in the future.");
        }

        private bool BeAValidRole(string role)
        {
            var validRoles = new[] { "Admin", "Teacher" };
            return validRoles.Contains(role);
        }
    }
}
