using FluentValidation;
using School_Managment_System1.Entities;
using School_Managment_System1.InterFaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class StudentGeneralRatesService : Service<StudentGeneralRate>, IStudentsGeneralRatesService
    {
        private readonly IStudentsGeneralRates _studentsGeneralRatesRepository;

        public StudentGeneralRatesService(IStudentsGeneralRates studentsGeneralRatesRepository, IValidator<StudentGeneralRate> validator)
            : base(studentsGeneralRatesRepository, validator)
        {
            _studentsGeneralRatesRepository = studentsGeneralRatesRepository;
        }

        /// <summary>
        /// Retrieves the general rate of a student by their ID.
        /// </summary>
        /// <param name="studentId">The ID of the student.</param>
        /// <returns>The general rate for the specified student, or null if not found.</returns>
        /// <exception cref="ArgumentException">Thrown when the student ID is less than or equal to zero.</exception>
        public async Task<StudentGeneralRate> GetByIdAsync(int studentId)
        {
            if (studentId <= 0)
            {
                throw new ArgumentException("Student ID must be a positive integer.", nameof(studentId));
            }

            return await _studentsGeneralRatesRepository.GetByIdAsync(studentId);
        }

        /// <summary>
        /// Retrieves all general rates for a student by their student general rate ID.
        /// </summary>
        /// <param name="studentGeneralRateId">The student's general rate ID.</param>
        /// <returns>A list of general rates for the specified student, or an empty list if none found.</returns>
        /// <exception cref="ArgumentException">Thrown when the student general rate ID is less than or equal to zero.</exception>
        public async Task<IEnumerable<StudentGeneralRate>> GetByStudentIdAsync(int studentGeneralRateId)
        {
            if (studentGeneralRateId <= 0)
            {
                throw new ArgumentException("Student general rate ID must be a positive integer.", nameof(studentGeneralRateId));
            }

            return await _studentsGeneralRatesRepository.GetByStudentIdAsync(studentGeneralRateId);
        }

        /// <summary>
        /// Retrieves all general rates for students that started in a given year.
        /// </summary>
        /// <param name="year">The starting year.</param>
        /// <returns>A list of general rates that started in the specified year, or an empty list if none found.</returns>
        /// <exception cref="ArgumentException">Thrown when the year is less than or equal to zero.</exception>
        public async Task<IEnumerable<StudentGeneralRate>> GetByStartYearAsync(int year)
        {
            if (year <= 0)
            {
                throw new ArgumentException("Year must be a positive integer.", nameof(year));
            }

            return await _studentsGeneralRatesRepository.GetByStartYearAsync(year);
        }

        /// <summary>
        /// Retrieves all general rates for students that ended in a given year.
        /// </summary>
        /// <param name="year">The ending year.</param>
        /// <returns>A list of general rates that ended in the specified year, or an empty list if none found.</returns>
        /// <exception cref="ArgumentException">Thrown when the year is less than or equal to zero.</exception>
        public async Task<IEnumerable<StudentGeneralRate>> GetByEndYearAsync(int year)
        {
            if (year <= 0)
            {
                throw new ArgumentException("Year must be a positive integer.", nameof(year));
            }

            return await _studentsGeneralRatesRepository.GetByEndYearAsync(year);
        }

        /// <summary>
        /// Retrieves all general rates for students with a specific rate.
        /// </summary>
        /// <param name="rate">The rate value.</param>
        /// <returns>A list of general rates with the specified rate, or an empty list if none found.</returns>
        public async Task<IEnumerable<StudentGeneralRate>> GetByRateAsync(decimal rate)
        {
            if (rate < 0)
            {
                throw new ArgumentException("Rate must be a positive value.", nameof(rate));
            }

            return await _studentsGeneralRatesRepository.GetByRateAsync(rate);
        }

        /// <summary>
        /// Retrieves all general rates for students in a specific class.
        /// </summary>
        /// <param name="className">The name of the class.</param>
        /// <returns>A list of general rates for students in the specified class, or an empty list if none found.</returns>
        /// <exception cref="ArgumentException">Thrown when the class name is null, empty, or whitespace.</exception>
        public async Task<IEnumerable<StudentGeneralRate>> GetByClassNameAsync(string className)
        {
            if (string.IsNullOrWhiteSpace(className))
            {
                throw new ArgumentException("Class name cannot be null, empty, or whitespace.", nameof(className));
            }

            return await _studentsGeneralRatesRepository.GetByClassNameAsync(className);
        }
    }
}
