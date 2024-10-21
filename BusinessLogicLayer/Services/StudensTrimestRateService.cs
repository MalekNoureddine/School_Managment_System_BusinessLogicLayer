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
    public class StudentsTrimestsRatesService : Service<StudensTrimestRate>, IStudentsTrimestsRatesService
    {
        private readonly IStudentsTrimestsRates _studentsTrimestsRatesRepository;

        public StudentsTrimestsRatesService(IStudentsTrimestsRates studentsTrimestsRatesRepository, IValidator<StudensTrimestRate> validator)
            : base(studentsTrimestsRatesRepository, validator)
        {
            _studentsTrimestsRatesRepository = studentsTrimestsRatesRepository;
        }

        /// <summary>
        /// Retrieves a trimester rate by its ID.
        /// </summary>
        /// <param name="studentTrimestRateId">The ID of the trimester rate.</param>
        /// <returns>The trimester rate with the specified ID, or null if not found.</returns>
        /// <exception cref="ArgumentException">Thrown when the trimester rate ID is less than or equal to zero.</exception>
        public async Task<StudensTrimestRate> GetByIdAsync(int studentTrimestRateId)
        {
            if (studentTrimestRateId <= 0)
            {
                throw new ArgumentException("Trimester rate ID must be a positive integer.", nameof(studentTrimestRateId));
            }

            return await _studentsTrimestsRatesRepository.GetByIdAsync(studentTrimestRateId);
        }

        /// <summary>
        /// Retrieves all trimester rates for a student in a specific trimester.
        /// </summary>
        /// <param name="studentId">The ID of the student.</param>
        /// <param name="trimest">The trimester number.</param>
        /// <returns>A list of trimester rates for the specified student and trimester, or an empty list if none found.</returns>
        /// <exception cref="ArgumentException">Thrown when the student ID or trimester is less than or equal to zero.</exception>
        public async Task<IEnumerable<StudensTrimestRate>> GetByStudentIDPerTrimestAsync(int studentId, int trimest)
        {
            if (studentId <= 0)
            {
                throw new ArgumentException("Student ID must be a positive integer.", nameof(studentId));
            }
            if (trimest <= 0)
            {
                throw new ArgumentException("Trimester must be a positive integer.", nameof(trimest));
            }

            return await _studentsTrimestsRatesRepository.GetByStudentIDPerTrimestAsync(studentId, trimest);
        }

        /// <summary>
        /// Retrieves all trimester rates for a student in a specific trimester and year.
        /// </summary>
        /// <param name="studentId">The ID of the student.</param>
        /// <param name="trimest">The trimester number.</param>
        /// <param name="year">The academic year.</param>
        /// <returns>A list of trimester rates for the specified student, trimester, and year, or an empty list if none found.</returns>
        public async Task<IEnumerable<StudensTrimestRate>> GetByStudentIDPerTrimestAsync(int studentId, int trimest, int year)
        {
            if (studentId <= 0)
            {
                throw new ArgumentException("Student ID must be a positive integer.", nameof(studentId));
            }
            if (trimest <= 0 || trimest > 3)
            {
                throw new ArgumentException("Trimester must be between 1 and 3.", nameof(trimest));
            }
            if (year <= 0)
            {
                throw new ArgumentException("Year must be a positive integer.", nameof(year));
            }

            return await _studentsTrimestsRatesRepository.GetByStudentIDPerTrimestAsync(studentId, trimest, year);
        }

        /// <summary>
        /// Retrieves all trimester rates for a student.
        /// </summary>
        /// <param name="studentId">The ID of the student.</param>
        /// <returns>A list of trimester rates for the specified student, or an empty list if none found.</returns>
        public async Task<IEnumerable<StudensTrimestRate>> GetByStudentIDAsync(int studentId)
        {
            if (studentId <= 0)
            {
                throw new ArgumentException("Student ID must be a positive integer.", nameof(studentId));
            }

            return await _studentsTrimestsRatesRepository.GetByStudentIDAsync(studentId);
        }

        /// <summary>
        /// Retrieves all trimester rates that started in a specific year.
        /// </summary>
        /// <param name="startYear">The starting year.</param>
        /// <returns>A list of trimester rates that started in the specified year, or an empty list if none found.</returns>
        public async Task<IEnumerable<StudensTrimestRate>> GetByStartYearAsync(int startYear)
        {
            if (startYear <= 0)
            {
                throw new ArgumentException("Start year must be a positive integer.", nameof(startYear));
            }

            return await _studentsTrimestsRatesRepository.GetByStartYearAsync(startYear);
        }

        /// <summary>
        /// Retrieves all trimester rates that ended in a specific year.
        /// </summary>
        /// <param name="endYear">The ending year.</param>
        /// <returns>A list of trimester rates that ended in the specified year, or an empty list if none found.</returns>
        public async Task<IEnumerable<StudensTrimestRate>> GetByEndYearAsync(int endYear)
        {
            if (endYear <= 0)
            {
                throw new ArgumentException("End year must be a positive integer.", nameof(endYear));
            }

            return await _studentsTrimestsRatesRepository.GetByEndYearAsync(endYear);
        }

        /// <summary>
        /// Retrieves all trimester rates for a student in a specific subject for a specific trimester.
        /// </summary>
        /// <param name="studentId">The ID of the student.</param>
        /// <param name="trimest">The trimester number.</param>
        /// <param name="subject">The ID of the subject.</param>
        /// <returns>A list of trimester rates for the specified student, trimester, and subject, or an empty list if none found.</returns>
        public async Task<IEnumerable<StudensTrimestRate>> GetByStudentIDPerSubjectPerTrimesAsync(int studentId, int trimest, int subject)
        {
            if (studentId <= 0)
            {
                throw new ArgumentException("Student ID must be a positive integer.", nameof(studentId));
            }
            if (trimest <= 0 || trimest > 3)
            {
                throw new ArgumentException("Trimester must be between 1 and 3.", nameof(trimest));
            }
            if (subject <= 0)
            {
                throw new ArgumentException("Subject ID must be a positive integer.", nameof(subject));
            }

            return await _studentsTrimestsRatesRepository.GetByStudentIDPerSubjectPerTrimesAsync(studentId, trimest, subject);
        }

        /// <summary>
        /// Retrieves a trimester rate for a student in a specific subject for a specific trimester and year.
        /// </summary>
        /// <param name="studentId">The ID of the student.</param>
        /// <param name="trimest">The trimester number.</param>
        /// <param name="subjectId">The ID of the subject.</param>
        /// <param name="startYear">The starting year.</param>
        /// <returns>The trimester rate for the specified student, trimester, subject, and year, or null if not found.</returns>
        public async Task<StudensTrimestRate> GetByStudentIDPerSubjectPerTrimesAsync(int studentId, int trimest, int subjectId, int startYear)
        {
            if (studentId <= 0)
            {
                throw new ArgumentException("Student ID must be a positive integer.", nameof(studentId));
            }
            if (trimest <= 0 || trimest > 3)
            {
                throw new ArgumentException("Trimester must be between 1 and 3.", nameof(trimest));
            }
            if (subjectId <= 0)
            {
                throw new ArgumentException("Subject ID must be a positive integer.", nameof(subjectId));
            }
            if (startYear <= 0)
            {
                throw new ArgumentException("Start year must be a positive integer.", nameof(startYear));
            }

            return await _studentsTrimestsRatesRepository.GetByStudentIDPerSubjectPerTrimesAsync(studentId, trimest, subjectId, startYear);
        }

        /// <summary>
        /// Retrieves a trimester rate for a student in a specific subject for a specific trimester and year, by subject name.
        /// </summary>
        /// <param name="studentId">The ID of the student.</param>
        /// <param name="trimest">The trimester number.</param>
        /// <param name="subjectName">The name of the subject.</param>
        /// <param name="startYear">The starting year.</param>
        /// <returns>The trimester rate for the specified student, trimester, subject name, and year, or null if not found.</returns>
        public async Task<StudensTrimestRate> GetByStudentIDPerSubjectPerTrimesAsync(int studentId, int trimest, string subjectName, int startYear)
        {
            if (studentId <= 0)
            {
                throw new ArgumentException("Student ID must be a positive integer.", nameof(studentId));
            }
            if (trimest <= 0 || trimest > 3)
            {
                throw new ArgumentException("Trimester must be between 1 and 3.", nameof(trimest));
            }
            if (string.IsNullOrWhiteSpace(subjectName))
            {
                throw new ArgumentException("Subject name must not be empty.", nameof(subjectName));
            }
            if (startYear <= 0)
            {
                throw new ArgumentException("Start year must be a positive integer.", nameof(startYear));
            }

            return await _studentsTrimestsRatesRepository.GetByStudentIDPerSubjectPerTrimesAsync(studentId, trimest, subjectName, startYear);
        }

        /// <summary>
        /// Retrieves all trimester rates for a student in a specific subject across all trimesters.
        /// </summary>
        /// <param name="studentId">The ID of the student.</param>
        /// <param name="subjectId">The ID of the subject.</param>
        /// <returns>A list of trimester rates for the specified student and subject, or an empty list if none found.</returns>
        public async Task<IEnumerable<StudensTrimestRate>> GetByStudentIDPerSubjectInAllTrimestsAsync(int studentId, int subjectId)
        {
            if (studentId <= 0)
            {
                throw new ArgumentException("Student ID must be a positive integer.", nameof(studentId));
            }
            if (subjectId <= 0)
            {
                throw new ArgumentException("Subject ID must be a positive integer.", nameof(subjectId));
            }

            return await _studentsTrimestsRatesRepository.GetByStudentIDPerSubjectInAllTrimestsAsync(studentId, subjectId);
        }
    }

}
