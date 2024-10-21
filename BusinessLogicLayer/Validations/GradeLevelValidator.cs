using FluentValidation;
using School_Managment_System1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Validations
{
    internal class GradeLevelValidator : AbstractValidator<GradeLevel>
    {
        public GradeLevelValidator()
        {
            RuleFor(gl => gl.GradeLevelId)
                .GreaterThan(0).WithMessage("Grade Level ID must be greater than zero.");

            RuleFor(gl => gl.GradeName)
                .NotEmpty().WithMessage("Grade name is required.")
                .MaximumLength(100).WithMessage("Grade name must not exceed 100 characters.");
        }
    }
}
