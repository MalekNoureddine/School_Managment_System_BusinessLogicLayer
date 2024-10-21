using BusinessLogicLayer.Services.Interfaces;
using FluentValidation;
using School_Managment_System1.Entities;
using School_Managment_System1.InterFaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogicLayer.Services.StudentService;

namespace BusinessLogicLayer.Services
{
    internal class StudentService
    {
        public class StudentsService : Service<Student>, IStudentService
        {
            private readonly IStudents _studentsRepository;

            public StudentsService(IStudents studentsRepository, IValidator<Student> validator)
                : base(studentsRepository, validator)
            {
                _studentsRepository = studentsRepository;
            }

            /// <summary>
            /// Retrieves a student by their unique ID.
            /// </summary>
            /// <param name="StudentID">The student's unique identifier.</param>
            /// <returns>The student with the specified ID, or null if not found.</returns>
            /// <exception cref="ArgumentException">Thrown when StudentID is less than or equal to zero.</exception>
            public async Task<Student> GetByIDAsync(int StudentID)
            {
                if (StudentID <= 0)
                {
                    throw new ArgumentException("Student ID must be a positive integer.", nameof(StudentID));
                }

                return await _studentsRepository.GetByIDAsync(StudentID);
            }

            /// <summary>
            /// Retrieves students associated with a specific parent ID.
            /// </summary>
            /// <param name="ParentID">The parent's unique identifier.</param>
            /// <returns>A list of students related to the specified parent ID, or an empty list if none found.</returns>
            /// <exception cref="ArgumentException">Thrown when ParentID is less than or equal to zero.</exception>
            public async Task<IEnumerable<Student>> GetByParentIDAsync(int ParentID)
            {
                if (ParentID <= 0)
                {
                    throw new ArgumentException("Parent ID must be a positive integer.", nameof(ParentID));
                }

                return await _studentsRepository.GetByParentIDAsync(ParentID);
            }

            /// <summary>
            /// Retrieves students enrolled in a specific class.
            /// </summary>
            /// <param name="ClassName">The name of the class.</param>
            /// <returns>A list of students enrolled in the specified class, or an empty list if none found.</returns>
            /// <exception cref="ArgumentException">Thrown when ClassName is null, empty, or whitespace.</exception>
            public async Task<IEnumerable<Student>> GetByClassNameAsync(string ClassName)
            {
                if (string.IsNullOrWhiteSpace(ClassName))
                {
                    throw new ArgumentException("Class name cannot be null, empty, or whitespace.", nameof(ClassName));
                }

                return await _studentsRepository.GetByClassNameAsync(ClassName);
            }

            /// <summary>
            /// Retrieves students by their first name.
            /// </summary>
            /// <param name="FirstName">The first name of the student(s).</param>
            /// <returns>A list of students with the specified first name, or an empty list if none found.</returns>
            /// <exception cref="ArgumentException">Thrown when FirstName is null, empty, or whitespace.</exception>
            public async Task<IEnumerable<Student>> GetByFirstNameAsync(string FirstName)
            {
                if (string.IsNullOrWhiteSpace(FirstName))
                {
                    throw new ArgumentException("First name cannot be null, empty, or whitespace.", nameof(FirstName));
                }

                return await _studentsRepository.GetByFirstNameAsync(FirstName);
            }

            /// <summary>
            /// Retrieves students by their last name.
            /// </summary>
            /// <param name="LastName">The last name of the student(s).</param>
            /// <returns>A list of students with the specified last name, or an empty list if none found.</returns>
            /// <exception cref="ArgumentException">Thrown when LastName is null, empty, or whitespace.</exception>
            public async Task<IEnumerable<Student>> GeByLastNameAsync(string LastName)
            {
                if (string.IsNullOrWhiteSpace(LastName))
                {
                    throw new ArgumentException("Last name cannot be null, empty, or whitespace.", nameof(LastName));
                }

                return await _studentsRepository.GeByLastNameAsync(LastName);
            }

            /// <summary>
            /// Retrieves students by their full name (first and last name).
            /// </summary>
            /// <param name="FirstName">The first name of the student(s).</param>
            /// <param name="LastName">The last name of the student(s).</param>
            /// <returns>A list of students with the specified full name, or an empty list if none found.</returns>
            /// <exception cref="ArgumentException">Thrown when either FirstName or LastName is null, empty, or whitespace.</exception>
            public async Task<IEnumerable<Student>> GetByFullNameAsync(string FirstName, string LastName)
            {
                if (string.IsNullOrWhiteSpace(FirstName))
                {
                    throw new ArgumentException("First name cannot be null, empty, or whitespace.", nameof(FirstName));
                }

                if (string.IsNullOrWhiteSpace(LastName))
                {
                    throw new ArgumentException("Last name cannot be null, empty, or whitespace.", nameof(LastName));
                }

                return await _studentsRepository.GetByFullNameAsync(FirstName, LastName);
            }

            /// <summary>
            /// Retrieves students by their date of birth.
            /// </summary>
            /// <param name="DateOfBirth">The student's date of birth.</param>
            /// <returns>A list of students with the specified date of birth, or an empty list if none found.</returns>
            public async Task<IEnumerable<Student>> GetByDateOfBirthAsync(DateOnly DateOfBirth)
            {
                return await _studentsRepository.GetByDateOfBirthAsync(DateOfBirth);
            }
        }

    }
}
