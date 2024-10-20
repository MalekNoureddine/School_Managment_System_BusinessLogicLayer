using BusinessLogicLayer.Services.Interfaces;
using School_Managment_System1.Entities;

namespace School_Managment_System1.InterFaces.IRepositories
{
    public interface IExamsResultsService : IService<ExamResult>
    {
        Task<ExamResult> GetByIdAsync(int SrudentId, int ExamId);

        Task<IEnumerable<ExamResult>> GetByStudentIDAsync(int StudentID);
        Task<IEnumerable<ExamResult>> GetByExamIDAsync(int ExamID);
        Task<IEnumerable<ExamResult>> GetByExamNameAsync(string ExamName);
        Task<IEnumerable<ExamResult>> GetByScoreAsync(double Score);

    }

}
