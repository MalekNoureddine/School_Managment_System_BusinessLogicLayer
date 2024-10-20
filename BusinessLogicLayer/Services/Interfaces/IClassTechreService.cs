using School_Managment_System1.Entities;

namespace School_Managment_System1.InterFaces.IRepositories
{
    public interface IClassTechre : IRepository<ClassTeacher>
    {
        Task<ClassTeacher> GetByIdAsync(int id);
        Task<IEnumerable<ClassTeacher>> GetByClassNameAsync(string ClassName);
        Task<IEnumerable<ClassTeacher>> GetByTeacherIDAsync(int TeacherID);
    }

}
