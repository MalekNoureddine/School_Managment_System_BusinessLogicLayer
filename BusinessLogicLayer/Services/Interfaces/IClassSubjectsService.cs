using BusinessLogicLayer.Services.Interfaces;
using School_Managment_System1.Entities;

namespace School_Managment_System1.InterFaces.IRepositories
{
    public interface IClassSubjectsService : IService<ClassSubject>
    {
        Task<ClassSubject> GetClassSubjectByIdAsync(int id);
        Task<IEnumerable<ClassSubject>> GetClassSubjectByClassNameAsync(string ClassName);
        Task<IEnumerable<ClassSubject>> GetClassSubjectBySubjectIDAsync(int SubjectID);
        Task<IEnumerable<ClassSubject>> GetClassSubjectByTeacherIDAsync(int TeacherID);
        Task<IEnumerable<ClassSubject>> GetClassSubjectBySubjectFactoryAsync(int SubjectFactory);
    }

}
