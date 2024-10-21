using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Validations
{
    using FluentValidation;
    using School_Managment_System1.Entities;

    internal class ClassSubjectValidator : AbstractValidator<ClassSubject>
    {
        public ClassSubjectValidator()
        {
            RuleFor(cs => cs.ClassName)
                .NotEmpty().WithMessage("Class name is required.")
                .MaximumLength(100).WithMessage("Class name must not exceed 100 characters.");

            RuleFor(cs => cs.SubjectId)
                .GreaterThan(0).WithMessage("Subject ID must be greater than zero.");

            RuleFor(cs => cs.TeacherId)
                .GreaterThan(0).WithMessage("Teacher ID must be greater than zero.");

            RuleFor(cs => cs.SubjectFactor)
                .InclusiveBetween(1, 10).WithMessage("Subject Factor must be between 1 and 10.")
                .When(cs => cs.SubjectFactor.HasValue); // Validate only if SubjectFactor is provided
        }
    }

}
