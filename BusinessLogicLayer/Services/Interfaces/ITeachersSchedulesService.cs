using BusinessLogicLayer.Services.Interfaces;
using School_Managment_System1.Entities;

namespace School_Managment_System1.InterFaces.IRepositories
{
    public interface ITeachersSchedulesService : IService<TeacherSchedule>
    {
        Task<TeacherSchedule> GetByIdAsync(int id);
        Task<TeacherSchedule> GetByTeacherIdAsync(int TeacherId);
        Task<IEnumerable<TeacherSchedule>> GetBySubjectIdAsync(int SubjectId);
        Task<IEnumerable<TeacherSchedule>> GetBySubjectIdAndTeacherIdAsync(int SubjectId, int TeacherId);
        Task<IEnumerable<TeacherSchedule>> GetBySubjectIdAndTeacherIdAndClassNameAsync(int SubjectId, int TeacherId, string ClassName);
        Task<IEnumerable<TeacherSchedule>> GetByStartTimeAsync(TimeOnly StartAt);
        Task<IEnumerable<TeacherSchedule>> GetByEndingTimeAsync(TimeOnly EndsAt);
        Task<IEnumerable<TeacherSchedule>> GetByTimeAsync(TimeOnly StartsAt, TimeOnly EndsAt);
        Task<IEnumerable<TeacherSchedule>> GetByNameAsync(string ClassName);
        Task<IEnumerable<TeacherSchedule>> GetByDayOfTheWeekAsync(string DayOfWeek);
    }
}
