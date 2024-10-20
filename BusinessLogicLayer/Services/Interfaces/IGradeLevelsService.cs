using BusinessLogicLayer.Services.Interfaces;
using School_Managment_System1.Entities;

namespace School_Managment_System1.InterFaces.IRepositories
{
    public interface IGradeLevelsService : IService<GradeLevel>
    {
        Task<GradeLevel> GetByIDAsync(int ID);
        Task<GradeLevel> GetByNameAsync(string Name);
    }

}
