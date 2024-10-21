using FluentValidation;
using School_Managment_System1.Entities;
using School_Managment_System1.InterFaces.IRepositories;
using School_Managment_System1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ExamsService : Service<Exam>, IExamsService
    {
        private readonly IExams _examsRepository;

        public ExamsService(IExams examsRepository, IValidator<Exam> validator)
            : base(examsRepository, validator)
        {
            _examsRepository = examsRepository;
        }

        /// <summary>
        /// Retrieves an exam by its ID.
        /// </summary>
        /// <param name="examID">The ID of the exam.</param>
        /// <returns>The exam with the specified ID.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the exam ID is less than or equal to zero.</exception>
        public async Task<Exam> GetExamByID(int examID)
        {
            if (examID <= 0)
            {
                throw new ArgumentOutOfRangeException("Exam ID must be a positive integer.", nameof(examID));
            }
            return await _examsRepository.GetExamByID(examID);
        }

        /// <summary>
        /// Retrieves an exam by its name.
        /// </summary>
        /// <param name="examName">The name of the exam.</param>
        /// <returns>The exam with the specified name.</returns>
        /// <exception cref="ArgumentException">Thrown when the exam name is null, empty, or whitespace.</exception>
        public async Task<Exam> GetExamByName(string examName)
        {
            if (string.IsNullOrWhiteSpace(examName))
            {
                throw new ArgumentException("Exam name cannot be null or empty.", nameof(examName));
            }
            return await _examsRepository.GetExamByName(examName);
        }

        /// <summary>
        /// Retrieves exams by trimester.
        /// </summary>
        /// <param name="trimester">The trimester to filter exams.</param>
        /// <returns>A list of exams for the specified trimester.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the trimester value is less than or equal to zero or greater than 3.</exception>
        public async Task<IEnumerable<Exam>> GetByTrimesterAsync(int trimester)
        {
            if (trimester <= 0 || trimester > 3)
            {
                throw new ArgumentOutOfRangeException("Trimester must be a between 0 and 3.", nameof(trimester));
            }
            return await _examsRepository.GetByTrimesterAsync(trimester);
        }

        /// <summary>
        /// Retrieves exams by class subject ID.
        /// </summary>
        /// <param name="classSubjectId">The ID of the class subject.</param>
        /// <returns>A list of exams for the specified class subject.</returns>
        // <exception cref="ArgumentException">Thrown when the class subject ID is less than or equal to zero.</exception>
        public async Task<IEnumerable<Exam>> GetByClassSubjectIdAsync(int classSubjectId)
        {
            if (classSubjectId <= 0)
            {
                throw new ArgumentException("Class Subject ID must be a positive integer.", nameof(classSubjectId));
            }
            return await _examsRepository.GetByClassSubjectIdAsync(classSubjectId);
        }

        /// <summary>
        /// Retrieves exams by scheduled date.
        /// </summary>
        /// <param name="dateScheduled">The date when the exam is scheduled.</param>
        /// <returns>A list of exams scheduled on the specified date.</returns>
        public async Task<IEnumerable<Exam>> GetByDateScheduledAsync(DateOnly dateScheduled)
        {
            return await _examsRepository.GetByDateScheduledAsync(dateScheduled);
        }
    }

}
