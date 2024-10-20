using BusinessLogicLayer.Services.Interfaces;
using School_Managment_System1.Entities;

namespace School_Managment_System1.InterFaces.IRepositories
{
    public interface IClassSubjectsService : IService<ClassSubject>
    {
        Task<ClassSubject> GetByIdAsync(int id);
        Task<IEnumerable<ClassSubject>> GetByClassNameAsync(string ClassName);
        Task<IEnumerable<ClassSubject>> GetBySubjectIDAsync(int SubjectID);
        Task<IEnumerable<ClassSubject>> GetByTeacherIDAsync(int TeacherID);
        Task<IEnumerable<ClassSubject>> GetBySubjectFactoryAsync(int SubjectFactory);
    }

}
