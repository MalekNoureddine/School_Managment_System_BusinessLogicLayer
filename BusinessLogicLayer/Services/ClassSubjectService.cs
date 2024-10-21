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
    public class ClassSubjectsService : Service<ClassSubject>, IClassSubjectsService
    {
        private readonly IClassSubjects _classSubjectsRepository;

        public ClassSubjectsService(IClassSubjects classSubjectsRepository, IValidator<ClassSubject> validator)
            : base(classSubjectsRepository, validator)
        {
            _classSubjectsRepository = classSubjectsRepository;
        }

        /// <summary>
        /// Retrieves a class subject by its ID.
        /// </summary>
        /// <param name="id">The ID of the class subject.</param>
        /// <returns>The class subject associated with the specified ID.</returns>
        /// <exception cref="ArgumentException">Thrown when the ID is less than or equal to zero.</exception>
        public async Task<ClassSubject> GetClassSubjectByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be a positive integer.", nameof(id));
            }

            return await _classSubjectsRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Retrieves class subjects by class name.
        /// </summary>
        /// <param name="className">The name of the class.</param>
        /// <returns>A collection of class subjects associated with the specified class name.</returns>
        /// <exception cref="ArgumentException">Thrown when the class name is null or empty.</exception>
        public async Task<IEnumerable<ClassSubject>> GetClassSubjectByClassNameAsync(string className)
        {
            if (string.IsNullOrWhiteSpace(className))
            {
                throw new ArgumentException("Class name cannot be null or empty.", nameof(className));
            }

            return await _classSubjectsRepository.GetByClassNameAsync(className);
        }

        /// <summary>
        /// Retrieves class subjects by subject ID.
        /// </summary>
        /// <param name="subjectID">The ID of the subject.</param>
        /// <returns>A collection of class subjects associated with the specified subject ID.</returns>
        /// <exception cref="ArgumentException">Thrown when the subject ID is less than or equal to zero.</exception>
        public async Task<IEnumerable<ClassSubject>> GetClassSubjectBySubjectIDAsync(int subjectID)
        {
            if (subjectID <= 0)
            {
                throw new ArgumentException("Subject ID must be a positive integer.", nameof(subjectID));
            }

            return await _classSubjectsRepository.GetBySubjectIDAsync(subjectID);
        }

        /// <summary>
        /// Retrieves class subjects by teacher ID.
        /// </summary>
        /// <param name="teacherID">The ID of the teacher.</param>
        /// <returns>A collection of class subjects associated with the specified teacher ID.</returns>
        /// <exception cref="ArgumentException">Thrown when the teacher ID is less than or equal to zero.</exception>
        public async Task<IEnumerable<ClassSubject>> GetClassSubjectByTeacherIDAsync(int teacherID)
        {
            if (teacherID <= 0)
            {
                throw new ArgumentException("Teacher ID must be a positive integer.", nameof(teacherID));
            }

            return await _classSubjectsRepository.GetByTeacherIDAsync(teacherID);
        }

        /// <summary>
        /// Retrieves class subjects by subject factory.
        /// </summary>
        /// <param name="subjectFactory">The factory ID associated with the subject.</param>
        /// <returns>A collection of class subjects associated with the specified subject factory.</returns>
        /// <exception cref="ArgumentException">Thrown when the subject factory ID is less than or equal to zero.</exception>
        public async Task<IEnumerable<ClassSubject>> GetClassSubjectBySubjectFactoryAsync(int subjectFactory)
        {
            if (subjectFactory <= 0)
            {
                throw new ArgumentException("Subject factory ID must be a positive integer.", nameof(subjectFactory));
            }

            return await _classSubjectsRepository.GetBySubjectFactoryAsync(subjectFactory);
        }
    }

}
