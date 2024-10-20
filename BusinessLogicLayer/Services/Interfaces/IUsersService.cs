using BusinessLogicLayer.Services.Interfaces;
using School_Managment_System1.Entities;

namespace School_Managment_System1.InterFaces.IRepositories
{
    public interface IUsersService : IService<User>
    {
        Task<User> GetByIdAsync(int UserId);
        Task<User> GetByNameAsync(string Username);
        Task<User> GetByPasswordHashAsync(string PasswordHash);
        Task<IEnumerable<User>> GetByRoleAsync(string Role);
        Task<User> GetByEmailAsync(string Email);

        Task<IEnumerable<User>> GetByFirstNameAsync(string FirstName);
        Task<IEnumerable<User>> GetByLastNameAsync(string LastName);
        Task<IEnumerable<User>> GetUsersCreatedAtAsync(DateTime CreatedAt);
        
    }
}
