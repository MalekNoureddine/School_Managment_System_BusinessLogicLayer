using FluentValidation;
using School_Managment_System1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Validations
{
    public class StudentsTrimestRateValidator : AbstractValidator<StudensTrimestRate>
    {
        public StudentsTrimestRateValidator()
        {
            RuleFor(s => s.StudentRateId)
                .GreaterThan(0).WithMessage("Student Rate ID must be greater than zero.");

            RuleFor(s => s.StudentId)
                .GreaterThan(0).WithMessage("Student ID must be greater than zero.");

            RuleFor(s => s.SubjectID)
                .GreaterThan(0).WithMessage("Subject ID must be greater than zero.");

            RuleFor(s => s.Trimester)
                .InclusiveBetween(1, 3).WithMessage("Trimester must be between 1 and 3.");

            RuleFor(s => s.StartYear)
                .GreaterThan(2000).WithMessage("Start Year must be greater than 2000.");

            RuleFor(s => s.EndYear)
                .GreaterThanOrEqualTo(s => s.StartYear).WithMessage("End Year must be greater than or equal to Start Year.");

            RuleFor(s => s.InClassActivitiesNote)
                .InclusiveBetween(0, 20).When(x => x.InClassActivitiesNote.HasValue)
                .WithMessage("In-Class Activities Note must be between 0 and 20.");

            RuleFor(s => s.FirstTestNote)
                .InclusiveBetween(0, 20).When(x => x.FirstTestNote.HasValue)
                .WithMessage("First Test Note must be between 0 and 20.");

            RuleFor(s => s.SecondTestNote)
                .InclusiveBetween(0, 20).When(x => x.SecondTestNote.HasValue)
                .WithMessage("Second Test Note must be between 0 and 20.");

            RuleFor(s => s.ExameNote)
                .InclusiveBetween(0, 20).When(x => x.ExameNote.HasValue)
                .WithMessage("Exam Note must be between 0 and 20.");

            RuleFor(s => s.Rate)
                .InclusiveBetween(0, 20).When(x => x.Rate.HasValue)
                .WithMessage("Rate must be between 0 and 100.");
        }
    }
}
