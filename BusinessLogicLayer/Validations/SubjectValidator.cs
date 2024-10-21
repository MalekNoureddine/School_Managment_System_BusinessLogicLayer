using FluentValidation;
using School_Managment_System1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Validations
{
    public class SubjectValidator : AbstractValidator<Subject>
    {
        public SubjectValidator()
        {
            RuleFor(s => s.SubjectId)
                .GreaterThan(0).WithMessage("Subject ID must be greater than zero.");

            RuleFor(s => s.SubjectName)
                .NotEmpty().WithMessage("Subject Name is required.")
                .Length(2, 100).WithMessage("Subject Name must be between 2 and 100 characters.");
        }
    }
}
