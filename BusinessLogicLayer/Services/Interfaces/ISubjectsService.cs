using BusinessLogicLayer.Services.Interfaces;
using School_Managment_System1.Entities;

namespace School_Managment_System1.InterFaces.IRepositories
{
    public interface ISubjectsService : IService<Subject>
    {
        Task<Subject> GetByIdAsync(int SubjectID);
        Task<Subject> GetByNameAsync(string SubjectName);
    }
}
