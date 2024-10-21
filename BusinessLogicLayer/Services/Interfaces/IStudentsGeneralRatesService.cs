using BusinessLogicLayer.Services.Interfaces;
using School_Managment_System1.Entities;

namespace School_Managment_System1.InterFaces.IRepositories
{
    public interface IStudentsGeneralRatesService : IService<StudentGeneralRate>
    {
        Task<StudentGeneralRate> GetByIdAsync(int studentId);
        Task<IEnumerable<StudentGeneralRate>> GetByStudentIdAsync(int studentGeneralRateId);
        Task<IEnumerable<StudentGeneralRate>> GetByStartYearAsync(int year);
        Task<IEnumerable<StudentGeneralRate>> GetByEndYearAsync(int year);
        Task<IEnumerable<StudentGeneralRate>> GetByRateAsync(decimal rate);
        Task<IEnumerable<StudentGeneralRate>> GetByClassNameAsync(string ClassName);
    }

}
