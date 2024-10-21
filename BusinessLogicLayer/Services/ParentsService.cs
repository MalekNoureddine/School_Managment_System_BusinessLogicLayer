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
    public class ParentsService : Service<Parent>, IParentsService
    {
        private readonly IParents _parentsRepository;

        public ParentsService(IParents parentsRepository, IValidator<Parent> validator)
            : base(parentsRepository, validator)
        {
            _parentsRepository = parentsRepository;
        }

        /// <summary>
        /// Retrieves a parent by their ID.
        /// </summary>
        /// <param name="parentId">The ID of the parent.</param>
        /// <returns>The parent with the specified ID, or null if not found.</returns>
        /// <exception cref="ArgumentException">Thrown when the parent ID is less than or equal to zero.</exception>
        public async Task<Parent> GetByIDAsync(int parentId)
        {
            if (parentId <= 0)
            {
                throw new ArgumentException("Parent ID must be a positive integer.", nameof(parentId));
            }

            return await _parentsRepository.GetByIDAsync(parentId);
        }

        /// <summary>
        /// Retrieves a parent by the student's ID.
        /// </summary>
        /// <param name="studentId">The ID of the student.</param>
        /// <returns>The parent associated with the student, or null if not found.</returns>
        /// <exception cref="ArgumentException">Thrown when the student ID is less than or equal to zero.</exception>
        public async Task<Parent> GetByStudentIDAsync(int studentId)
        {
            if (studentId <= 0)
            {
                throw new ArgumentException("Student ID must be a positive integer.", nameof(studentId));
            }

            return await _parentsRepository.GetByStudentIDAsync(studentId);
        }

        /// <summary>
        /// Retrieves parents by their first name.
        /// </summary>
        /// <param name="firstName">The first name of the parent.</param>
        /// <returns>A list of parents with the specified first name, or an empty list if none found.</returns>
        /// <exception cref="ArgumentException">Thrown when the first name is null, empty, or whitespace.</exception>
        public async Task<IEnumerable<Parent>> GetByFirstNameAsync(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name cannot be null, empty, or whitespace.", nameof(firstName));
            }

            return await _parentsRepository.GetByFirstNameAsync(firstName);
        }

        /// <summary>
        /// Retrieves parents by their last name.
        /// </summary>
        /// <param name="lastName">The last name of the parent.</param>
        /// <returns>A list of parents with the specified last name, or an empty list if none found.</returns>
        /// <exception cref="ArgumentException">Thrown when the last name is null, empty, or whitespace.</exception>
        public async Task<IEnumerable<Parent>> GetByLastNameAsync(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Last name cannot be null, empty, or whitespace.", nameof(lastName));
            }

            return await _parentsRepository.GetByLastNameAsync(lastName);
        }

        /// <summary>
        /// Retrieves a parent by their phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number of the parent.</param>
        /// <returns>The parent with the specified phone number, or null if not found.</returns>
        /// <exception cref="ArgumentException">Thrown when the phone number is null, empty, or whitespace.</exception>
        public async Task<Parent> GetByPhoneNumberAsync(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new ArgumentException("Phone number cannot be null, empty, or whitespace.", nameof(phoneNumber));
            }

            return await _parentsRepository.GetByPhoneNumberAsync(phoneNumber);
        }

        /// <summary>
        /// Retrieves a parent by their email address.
        /// </summary>
        /// <param name="email">The email address of the parent.</param>
        /// <returns>The parent with the specified email address, or null if not found.</returns>
        /// <exception cref="ArgumentException">Thrown when the email address is null, empty, or whitespace.</exception>
        public async Task<Parent> GetByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null, empty, or whitespace.", nameof(email));
            }
            
            return await _parentsRepository.GetByEmailAsync(email);
        }
    }

}
