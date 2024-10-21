using BusinessLogicLayer.Services.Interfaces;
using School_Managment_System1.Entities;

namespace School_Managment_System1.InterFaces.IRepositories
{
    public interface ITeachersService : IService<Teacher>
    {
        Task<Teacher> GetTeacherByIdAsync(int TeacherId);
        Task<Teacher> GetTeacherByUserIdAsync(int UserID);
        Task<IEnumerable<Teacher>> GetTeachersByFirstNameAsync(string FirstName);
        Task<IEnumerable<Teacher>> GetTeachersByLastNameAsync(string LastName);
        Task<IEnumerable<Teacher>> GetTeachersBySubjectSpecializationAsync(string SubjectSpecialization);
        Task<IEnumerable<Teacher>> GetTeachersByClassNameAsync(string ClassName);
        Task<Teacher> GetTeacherByPhoneNumberAsync(string PhoneNumber);
        Task<Teacher> GetTeacherByEmailAsync(string Email);
    }
}
