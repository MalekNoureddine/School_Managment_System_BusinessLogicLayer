using FluentValidation;
using School_Managment_System1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Validations
{
    internal class ClassTeacherValidator : AbstractValidator<ClassTeacher>
    {
        public ClassTeacherValidator()
        {

            RuleFor(ct => ct.ClassName)
                .NotEmpty().WithMessage("Class name is required.")
                .MaximumLength(100).WithMessage("Class name must not exceed 100 characters.");

            RuleFor(ct => ct.TeacherId)
                .GreaterThan(0).WithMessage("Teacher ID must be greater than zero.");
        }
    }
}
