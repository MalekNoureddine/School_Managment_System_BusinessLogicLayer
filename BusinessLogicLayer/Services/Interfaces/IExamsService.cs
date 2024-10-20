using BusinessLogicLayer.Services.Interfaces;
using School_Managment_System1.Entities;

namespace School_Managment_System1.InterFaces.IRepositories
{
    public interface IExamsService : IService<Exam>
    {
        Task<Exam> GetExamByID(int ExamID);
        Task<Exam> GetExamByName(string ExamName);
        Task<IEnumerable<Exam>> GetByTrimesterAsync(int Trimester);
        Task<IEnumerable<Exam>> GetByClassSubjectIdAsync(int ClassSubjectId);
        Task<IEnumerable<Exam>> GetByDateScheduledAsync(DateOnly DateScheduled);

    }

}
