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
    public class ExamsResultsService : Service<ExamResult>, IExamsResultsService
    {
        private readonly IExamsResults _examsResultsRepository;

        public ExamsResultsService(IExamsResults examsResultsRepository, IValidator<ExamResult> validator)
            : base(examsResultsRepository, validator)
        {
            _examsResultsRepository = examsResultsRepository;
        }

        /// <summary>
        /// Retrieves an exam result by student ID and exam ID.
        /// </summary>
        /// <param name="studentId">The ID of the student.</param>
        /// <param name="examId">The ID of the exam.</param>
        /// <returns>The exam result for the specified student and exam.</returns>
        public async Task<ExamResult> GetByIdAsync(int studentId, int examId)
        {
            if (studentId <= 0 || examId <= 0)
            {
                throw new ArgumentException("IDs must be positive integers.");
            }
            return await _examsResultsRepository.GetByIdAsync(studentId, examId);
        }

        /// <summary>
        /// Retrieves exam results by student ID.
        /// </summary>
        /// <param name="studentID">The ID of the student.</param>
        /// <returns>A list of exam results for the specified student.</returns>
        public async Task<IEnumerable<ExamResult>> GetByStudentIDAsync(int studentID)
        {
            if (studentID <= 0)
            {
                throw new ArgumentException("Student ID must be a positive integer.");
            }
            return await _examsResultsRepository.GetByStudentIDAsync(studentID);
        }

        /// <summary>
        /// Retrieves exam results by exam ID.
        /// </summary>
        /// <param name="examID">The ID of the exam.</param>
        /// <returns>A list of exam results for the specified exam.</returns>
        public async Task<IEnumerable<ExamResult>> GetByExamIDAsync(int examID)
        {
            if (examID <= 0)
            {
                throw new ArgumentException("Exam ID must be a positive integer.");
            }
            return await _examsResultsRepository.GetByExamIDAsync(examID);
        }

        /// <summary>
        /// Retrieves exam results by exam name.
        /// </summary>
        /// <param name="examName">The name of the exam.</param>
        /// <returns>A list of exam results for the specified exam name.</returns>
        public async Task<IEnumerable<ExamResult>> GetByExamNameAsync(string examName)
        {
            if (string.IsNullOrWhiteSpace(examName))
            {
                throw new ArgumentException("Exam name cannot be null or empty.", nameof(examName));
            }
            return await _examsResultsRepository.GetByExamNameAsync(examName);
        }

        /// <summary>
        /// Retrieves exam results by score.
        /// </summary>
        /// <param name="score">The score to filter exam results.</param>
        /// <returns>A list of exam results that match the specified score.</returns>
        public async Task<IEnumerable<ExamResult>> GetByScoreAsync(double score)
        {
            if (score > 20 || score < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(score) + " should be between 0 and 20");
            }
            return await _examsResultsRepository.GetByScoreAsync(score);
        }
    }

}
