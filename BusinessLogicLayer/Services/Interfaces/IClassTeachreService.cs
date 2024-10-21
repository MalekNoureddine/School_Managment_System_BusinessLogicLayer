using BusinessLogicLayer.Services.Interfaces;
using School_Managment_System1.Entities;

namespace School_Managment_System1.InterFaces.IRepositories
{
    public interface IClassTeacherService : IService<ClassTeacher>
    {
        public Task<ClassTeacher> GetByIdAsync(int id);
        public Task<IEnumerable<ClassTeacher>> GetByClassNameAsync(string ClassName);
        public Task<IEnumerable<ClassTeacher>> GetByTeacherIDAsync(int TeacherID);
    }

}
