using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Validations
{
    using FluentValidation;
    using School_Managment_System1.Entities;

    public class AttendanceValidator : AbstractValidator<Attendance>
    {
        public AttendanceValidator()
        {
            // AttendanceId must be greater than 0
            RuleFor(a => a.AttendanceId)
                .GreaterThan(0)
                .WithMessage("Attendance ID must be greater than 0.");

            // StudentId must be greater than 0
            RuleFor(a => a.StudentId)
                .GreaterThan(0)
                .WithMessage("Student ID must be greater than 0.");

            // ClassName should not be null, empty, or whitespace
            RuleFor(a => a.ClassName)
                .NotEmpty()
                .WithMessage("Class name cannot be empty.")
                .MaximumLength(100)
                .WithMessage("Class name cannot exceed 100 characters.");

            // SessionId must be greater than 0
            RuleFor(a => a.SessionId)
                .GreaterThan(0)
                .WithMessage("Session ID must be greater than 0.");

            // Date must be today or a past date, not a future date
            RuleFor(a => a.Date)
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
                .WithMessage("Attendance date cannot be in the future.");

            // Status must be either "Present" or "Absent"
            RuleFor(a => a.Status)
                .NotEmpty()
                .WithMessage("Status cannot be empty.")
                .Must(status => status == "Present" || status == "Absent")
                .WithMessage("Status must be either 'Present' or 'Absent'.");

            // Ensure that the related entities (Session, Student, and Class) are not null
            RuleFor(a => a.Session)
                .NotNull()
                .WithMessage("Session information must be provided.");

            RuleFor(a => a.Student)
                .NotNull()
                .WithMessage("Student information must be provided.");

            RuleFor(a => a.Class)
                .NotNull()
                .WithMessage("Class information must be provided.");
        }
    }

}
