using BusinessLogicLayer.Services.Interfaces;
using School_Managment_System1.Entities;

namespace School_Managment_System1.InterFaces.IRepositories
{
    public interface ITeachersService : IService<Teacher>
    {
        Task<Teacher> GetByIDAsync(int TeacherId);
        Task<Teacher> GetByUserIDAsync(int UserID);
        Task<IEnumerable<Teacher>> GetByFirstNameAsync(string FirstName);
        Task<IEnumerable<Teacher>> GetByLastNameAsync(string LastName);
        Task<IEnumerable<Teacher>> GetBySubjectSpecializationAsync(string SubjectSpecialization);
        Task<IEnumerable<Teacher>> GetByClassNameAsync(string ClassName);
        Task<Teacher> GetByPhoneNumberAsync(string PhoneNumber);
        Task<Teacher> GetByEmailAsync(string Email);
    }
}
