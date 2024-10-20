using BusinessLogicLayer.Services.Interfaces;
using School_Managment_System1.Entities;

namespace School_Managment_System1.InterFaces.IRepositories
{
    public interface IParentsService : IService<Parent>
    {
        Task<Parent> GetByIDAsync(int ParentId);
        Task<Parent> GetByStudentIDAsync(int StudentId);
        Task<IEnumerable<Parent>> GetByFirstNameAsync(string FirstName);
        Task<IEnumerable<Parent>> GetByLastNameAsync(string LastName);
        Task<Parent> GetByPhoneNumberAsync(string PhoneNumber);
        Task<Parent> GetByEmailAsync(string Email);

    }

}
