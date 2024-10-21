using BusinessLogicLayer.Services.Interfaces;
using School_Managment_System1.Entities;

namespace School_Managment_System1.InterFaces.IRepositories
{
    public interface IUsersService : IService<User>
    {
        Task<User> GetByIdAsync(int userId);
        Task<User> GetByNameAsync(string username);
        Task<User> GetByPasswordHashAsync(string passwordHash);
        Task<IEnumerable<User>> GetByRoleAsync(string role);
        Task<User> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetByFirstNameAsync(string firstName);
        Task<IEnumerable<User>> GetByLastNameAsync(string lastName);
        Task<IEnumerable<User>> GetUsersCreatedAtAsync(DateTime createdAt);
    }
}
