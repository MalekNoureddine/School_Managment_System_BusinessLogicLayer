using FluentValidation;
using School_Managment_System1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Validations
{
    public class StudentGeneralRateValidator : AbstractValidator<StudentGeneralRate>
    {
        public StudentGeneralRateValidator()
        {
            RuleFor(sgr => sgr.StudentRateId)
                .GreaterThan(0).WithMessage("Student Rate ID must be greater than zero.");

            RuleFor(sgr => sgr.StudentId)
                .GreaterThan(0).WithMessage("Student ID must be greater than zero.");

            RuleFor(sgr => sgr.Rate)
                .InclusiveBetween(0, 100).WithMessage("Rate must be between 0 and 20.");

            RuleFor(sgr => sgr.StartYear)
                .GreaterThan(2000).WithMessage("Start year must be greater than 2000.");

            RuleFor(sgr => sgr.EndYear)
                .GreaterThan(sgr => sgr.StartYear).WithMessage("End year must be greater than the start year.");
        }
    }
}
