using FluentValidation;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Crypto.Generators;
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
    public class UsersService : Service<User>, IUsersService
    {
        private readonly IUsers _usersRepository;

        public UsersService(IUsers usersRepository, IValidator<User> validator)
            : base(usersRepository, validator)
        {
            _usersRepository = usersRepository;
        }

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The user with the specified ID, or null if not found.</returns>
        /// <exception cref="ArgumentException">Thrown when the user ID is less than or equal to zero.</exception>
        public async Task<User> GetByIdAsync(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentException("User ID must be a positive integer.", nameof(userId));
            }

            return await _usersRepository.GetByIdAsync(userId);
        }

        /// <summary>
        /// Retrieves a user by their username.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>The user with the specified username, or null if not found.</returns>
        /// <exception cref="ArgumentException">Thrown when the username is null or empty.</exception>
        public async Task<User> GetByNameAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username must not be empty.", nameof(username));
            }

            return await _usersRepository.GetByNameAsync(username);
        }

        /// <summary>
        /// Retrieves a user by their password hash.
        /// </summary>
        /// <param name="passwordHash">The password hash of the user.</param>
        /// <returns>The user with the specified password hash, or null if not found.</returns>
        /// <exception cref="ArgumentException">Thrown when the password hash is null or empty.</exception>
        public async Task<User> GetByPasswordHashAsync(string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(passwordHash))
            {
                throw new ArgumentException("Password hash must not be empty.", nameof(passwordHash));
            }

            return await _usersRepository.GetByPasswordHashAsync(passwordHash);
        }

        /// <summary>
        /// Retrieves users by their role.
        /// </summary>
        /// <param name="role">The role of the users.</param>
        /// <returns>A list of users with the specified role.</returns>
        /// <exception cref="ArgumentException">Thrown when the role is null or empty.</exception>
        public async Task<IEnumerable<User>> GetByRoleAsync(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
            {
                throw new ArgumentException("Role must not be empty.", nameof(role));
            }

            return await _usersRepository.GetByRoleAsync(role);
        }

        /// <summary>
        /// Retrieves a user by their email address.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <returns>The user with the specified email, or null if not found.</returns>
        /// <exception cref="ArgumentException">Thrown when the email is null or empty.</exception>
        public async Task<User> GetByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email must not be empty.", nameof(email));
            }

            return await _usersRepository.GetByEmailAsync(email);
        }

        /// <summary>
        /// Retrieves users by their first name.
        /// </summary>
        /// <param name="firstName">The first name of the users.</param>
        /// <returns>A list of users with the specified first name.</returns>
        /// <exception cref="ArgumentException">Thrown when the first name is null or empty.</exception>
        public async Task<IEnumerable<User>> GetByFirstNameAsync(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name must not be empty.", nameof(firstName));
            }

            return await _usersRepository.GetByFirstNameAsync(firstName);
        }

        /// <summary>
        /// Retrieves users by their last name.
        /// </summary>
        /// <param name="lastName">The last name of the users.</param>
        /// <returns>A list of users with the specified last name.</returns>
        /// <exception cref="ArgumentException">Thrown when the last name is null or empty.</exception>
        public async Task<IEnumerable<User>> GetByLastNameAsync(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Last name must not be empty.", nameof(lastName));
            }

            return await _usersRepository.GetByLastNameAsync(lastName);
        }

        /// <summary>
        /// adds a user to the users repository after validating it and hashing his password.
        /// </summary>
        /// <param name="user">The user to add.</param>
        public override void Add(User user)
        {
            Validate(user);
            user.PasswordHash = HashPasswordAsync(user.PasswordHash);
            _usersRepository.Add(user);
        }

        /// <summary>
        /// Asynchronously adds a user to the users repository after validating it and hashing his password.
        /// </summary>
        /// <param name="user">The user to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public override async Task AddAsync(User user)
        {
            Validate(user);
            user.PasswordHash = HashPasswordAsync(user.PasswordHash);
            await _usersRepository.AddAsync(user);
        }

        /// <summary>
        /// Adds a range of users to the users repository after validating each one and validating thier passowrd.
        /// </summary>
        /// <param name="users">The list of entities to add.</param>
        public override void AddRange(List<User> users)
        {
            foreach (var user in users)
            {
                Validate(user);
                user.PasswordHash = HashPasswordAsync(user.PasswordHash);
            }
            _usersRepository.AddRange(users);
        }
        /// <summary>
        /// Asynchronously adds a range of users to the users repository after validating each one and hashing thier passwords.
        /// </summary>
        /// <param name="users">The list of entities to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public override async Task AddRangeAsync(List<User> users)
        {
            foreach (var user in users)
            {
                Validate(user);
                user.PasswordHash = HashPasswordAsync(user.PasswordHash);
            }
            await _usersRepository.AddRangeAsync(users);
        }
        /// <summary>
        /// Retrieves users created at a specific date.
        /// </summary>
        /// <param name="createdAt">The date when the users were created.</param>
        /// <returns>A list of users created on the specified date.</returns>
        public async Task<IEnumerable<User>> GetUsersCreatedAtAsync(DateTime createdAt)
        {
            return await _usersRepository.GetUsersCreatedAtAsync(createdAt);
        }

        /// <summary>
        ///  updates a user after validating it and hashing the password..
        /// </summary>
        /// <param name="user">The user to update.</param>
        public override void Update(User user)
        {
            Validate(user);
            user.PasswordHash = HashPasswordAsync(user.PasswordHash);
            _usersRepository.Update(user);
        }
        /// <summary>
        /// Asynchronously updates a user after validating it and hashing the password.
        /// </summary>
        /// <param name="user">The user to update.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public override async Task UpdateAsync(User user)
        {
            Validate(user);
            user.PasswordHash = HashPasswordAsync(user.PasswordHash);
            await _usersRepository.UpdateAsync(user);
        }

        /// <summary>
        /// Hashes the user's password using bcrypt.
        /// </summary>
        /// <param name="password">The plain text password to be hashed.</param>
        /// <returns>The hashed password as a string.</returns>
        private string HashPasswordAsync(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be null, empty, or whitespace.", nameof(password));
            }

            // Hashing logic here (e.g., using BCrypt, PBKDF2, etc.)
            // Example with BCrypt:
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

    }

}
