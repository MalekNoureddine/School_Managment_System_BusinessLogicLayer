using FluentValidation;
using School_Managment_System1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Validations
{
    public class TeacherScheduleValidator : AbstractValidator<TeacherSchedule>
    {
        public TeacherScheduleValidator()
        {
            RuleFor(ts => ts.TeacherScheduleId)
                .GreaterThan(0).WithMessage("Teacher Schedule ID must be greater than zero.");

            RuleFor(ts => ts.TeacherId)
                .GreaterThan(0).WithMessage("Teacher ID must be greater than zero.");

            RuleFor(ts => ts.SubjectId)
                .GreaterThan(0).WithMessage("Subject ID must be greater than zero.");

            RuleFor(ts => ts.ClassName)
                .NotEmpty().WithMessage("Class Name is required.")
                .Length(2, 50).WithMessage("Class Name must be between 2 and 50 characters.");

            //RuleFor(cs => cs.DayOfWeek)
            //    .NotEmpty().WithMessage("Day of the week is required.")
            //    .Matches(@"^(Sunday|Monday|Tuesday|Wednesday|Thursday|Friday|Saturday)$")
            //    .WithMessage("Day of the week must be a valid day (Sunday to Saturday).");
            RuleFor(ts => ts.DayOfWeek)
                .NotEmpty().WithMessage("Day of Week is required.")
                .Must(BeAValidDay).WithMessage("Day of Week must be a valid day (e.g., Monday, Tuesday, etc.).");

            

            RuleFor(ts => ts.StartTime)
                .NotNull().WithMessage("Start Time is required.");

            RuleFor(ts => ts.EndTime)
                .NotNull().WithMessage("End Time is required.")
                .GreaterThan(ts => ts.StartTime).WithMessage("End Time must be greater than Start Time.");
        }

        private bool BeAValidDay(string day)
        {
            var validDays = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            return validDays.Contains(day);
        }
    }
}