using BusinessLogicLayer.Services.Interfaces;
using School_Managment_System1.Entities;

namespace School_Managment_System1.InterFaces.IRepositories
{
    public interface IclassesService : IService<Class>
    {

        Task<Class> GetByNameAsync(string ClassName);
        Task<IEnumerable<Class>> GetClassesByGradeLevelAsync(string GradeLevelName);
        Task<IEnumerable<Class>> GetClassesByGradeLevelAsync(int GradeLevelID);
    }

}
