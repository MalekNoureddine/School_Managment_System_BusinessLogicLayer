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
    public class TeachersService : Service<Teacher> , ITeachersService
    {
        private readonly ITeachers _teachersRepository;

        public TeachersService(ITeachers teachersRepository, IValidator<Teacher> teachersValidator)
            :base(teachersRepository, teachersValidator)
        {
            _teachersRepository = teachersRepository;
        }

        /// <summary>
        /// Retrieves a teacher by their ID.
        /// </summary>
        /// <param name="teacherId">The ID of the teacher.</param>
        /// <returns>The teacher with the specified ID, or null if not found.</returns>
        public async Task<Teacher> GetTeacherByIdAsync(int teacherId)
        {
            if (teacherId <= 0)
            {
                throw new ArgumentException("Teacher ID must be a positive integer.", nameof(teacherId));
            }

            return await _teachersRepository.GetByIDAsync(teacherId);
        }

        /// <summary>
        /// Retrieves a teacher by their user ID.
        /// </summary>
        /// <param name="userId">The user ID associated with the teacher.</param>
        /// <returns>The teacher with the specified user ID, or null if not found.</returns>
        public async Task<Teacher> GetTeacherByUserIdAsync(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentException("User ID must be a positive integer.", nameof(userId));
            }

            return await _teachersRepository.GetByUserIDAsync(userId);
        }

        /// <summary>
        /// Retrieves teachers by their first name.
        /// </summary>
        /// <param name="firstName">The first name of the teachers.</param>
        /// <returns>A list of teachers with the specified first name.</returns>
        public async Task<IEnumerable<Teacher>> GetTeachersByFirstNameAsync(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name must not be empty.", nameof(firstName));
            }

            return await _teachersRepository.GetByFirstNameAsync(firstName);
        }

        /// <summary>
        /// Retrieves teachers by their last name.
        /// </summary>
        /// <param name="lastName">The last name of the teachers.</param>
        /// <returns>A list of teachers with the specified last name.</returns>
        public async Task<IEnumerable<Teacher>> GetTeachersByLastNameAsync(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Last name must not be empty.", nameof(lastName));
            }

            return await _teachersRepository.GetByLastNameAsync(lastName);
        }

        /// <summary>
        /// Retrieves teachers by their subject specialization.
        /// </summary>
        /// <param name="subjectSpecialization">The subject specialization of the teachers.</param>
        /// <returns>A list of teachers specialized in the specified subject.</returns>
        public async Task<IEnumerable<Teacher>> GetTeachersBySubjectSpecializationAsync(string subjectSpecialization)
        {
            if (string.IsNullOrWhiteSpace(subjectSpecialization))
            {
                throw new ArgumentException("Subject specialization must not be empty.", nameof(subjectSpecialization));
            }

            return await _teachersRepository.GetBySubjectSpecializationAsync(subjectSpecialization);
        }

        /// <summary>
        /// Retrieves teachers by their associated class name.
        /// </summary>
        /// <param name="className">The name of the class.</param>
        /// <returns>A list of teachers associated with the specified class name.</returns>
        public async Task<IEnumerable<Teacher>> GetTeachersByClassNameAsync(string className)
        {
            if (string.IsNullOrWhiteSpace(className))
            {
                throw new ArgumentException("Class name must not be empty.", nameof(className));
            }

            return await _teachersRepository.GetByClassNameAsync(className);
        }

        /// <summary>
        /// Retrieves a teacher by their phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number of the teacher.</param>
        /// <returns>The teacher with the specified phone number, or null if not found.</returns>
        public async Task<Teacher> GetTeacherByPhoneNumberAsync(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new ArgumentException("Phone number must not be empty.", nameof(phoneNumber));
            }

            return await _teachersRepository.GetByPhoneNumberAsync(phoneNumber);
        }

        /// <summary>
        /// Retrieves a teacher by their email.
        /// </summary>
        /// <param name="email">The email of the teacher.</param>
        /// <returns>The teacher with the specified email, or null if not found.</returns>
        public async Task<Teacher> GetTeacherByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email must not be empty.", nameof(email));
            }

            return await _teachersRepository.GetByEmailAsync(email);
        }
    }

}
