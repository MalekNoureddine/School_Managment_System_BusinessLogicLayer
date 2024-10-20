using BusinessLogicLayer.Services.Interfaces;
using School_Managment_System1.Entities;

namespace School_Managment_System1.InterFaces.IRepositories
{
    public interface IClassesSchedulesService : IService<ClassSchedule>
    {
        Task<ClassSchedule> GetByIdAsync(int id);
        Task<IEnumerable<ClassSchedule>> GetBySubjectIdAsync(int SubjectId);
        Task<IEnumerable<ClassSchedule>> GetByStartTimeAsync(TimeOnly StartAt);
        Task<IEnumerable<ClassSchedule>> GetByEndingTimeAsync(TimeOnly EndsAt);
        Task<IEnumerable<ClassSchedule>> GetByTimeAsync(TimeOnly StartsAt, TimeOnly EndsAt);
        Task<IEnumerable<ClassSchedule>> GetByNameAsync(string ClassName);
        Task<IEnumerable<ClassSchedule>> GetByDayOfTheWeekAsync(string DayOfWeek);
    }

}
