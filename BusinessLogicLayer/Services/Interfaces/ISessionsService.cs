using BusinessLogicLayer.Services.Interfaces;
using School_Managment_System1.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace School_Managment_System1.InterFaces.IRepositories
{
    public interface ISessionsService : IService<Session>
    {
        Task<Session> GetByIDAsync(int SessionID);
        Task<IEnumerable<Session>> GetByClassSubjectIdAsync(int ClassSubjectId);
        Task<IEnumerable<Session>> GetByDateAsync(DateOnly Date);
        Task<IEnumerable<Session>> GetByStartTimeAsync(TimeOnly StartAt);
        Task<IEnumerable<Session>> GetByEndingTimeAsync(TimeOnly EndsAt);
        Task<IEnumerable<Session>> GetByTimeAsync(TimeOnly StartsAt, TimeOnly EndsAt);
    }

}
