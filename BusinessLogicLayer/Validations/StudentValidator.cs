using FluentValidation;
using School_Managment_System1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Validations
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(s => s.StudentId)
                .GreaterThan(0).WithMessage("Student ID must be greater than zero.");

            RuleFor(s => s.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .Length(1, 100).WithMessage("First name must be between 1 and 100 characters.");

            RuleFor(s => s.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .Length(1, 100).WithMessage("Last name must be between 1 and 100 characters.");

            RuleFor(s => s.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth is required.")
                .LessThan(DateOnly.FromDateTime(DateTime.Now)).WithMessage("Date of birth must be in the past.");

            RuleFor(s => s.ClassName)
                .NotEmpty().WithMessage("Class name is required.");

            RuleFor(s => s.ParentId)
                .GreaterThan(0).WithMessage("Parent ID must be greater than zero.");
        }
    }
}
