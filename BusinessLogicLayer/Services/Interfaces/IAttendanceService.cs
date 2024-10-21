using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School_Managment_System1.Entities;

namespace BusinessLogicLayer.Services.Interfaces
{
    internal interface IAttendanceService : IService<Attendance>
    {
        
            Task<Attendance> GetAttendanceByIdAsync(int id);
            //Task<IEnumerable<Attendance>> GetAllsAttendancesAsync();
            //Task MarkAttendanceAsync(Attendance attendance);
            //void MarkAttendance(Attendance attendance);
            //Task MarkAttendanceRangeAsync(List<Attendance> attendance);
            //void MarkAttendanceRange(List<Attendance> attendance);
            //Task UpdateAttendanceAsync(Attendance attendance);
            //void UpdateAttendance(Attendance attendance);
            //void DeleteAttendance(Attendance attendance);
            //Task DeleteAttendanceByIdAsync(int attendance);
            Task<IEnumerable<Attendance>> GetAttendanceByStudentIdAsync(int StudentID);
            Task<IEnumerable<Attendance>> GetAttendanceByClassNameAsync(string ClassName);
            Task<IEnumerable<Attendance>> GetAttendanceBySessionIdAsync(int SessionID);
            Task<IEnumerable<Attendance>> GetAttendanceByDateRangeAsync(DateOnly From, DateOnly To);
            Task<IEnumerable<Attendance>> GetAttendanceByDateAsync(DateOnly Date);
                                             
            Task<IEnumerable<Attendance>> GetAttendanceByStudentIdAsync_presents(int StudentID);
            Task<IEnumerable<Attendance>> GetAttendanceByClassNameAsync_presents(string ClassName);
            Task<IEnumerable<Attendance>> GetAttendanceBySessionIdAsync_presents(int SessionID);
            Task<IEnumerable<Attendance>> GetAttendanceByDateRangeAsync_presents(DateOnly From, DateOnly To);
            Task<IEnumerable<Attendance>> GetAttendanceByDateAsync_presents(DateOnly Date);

            Task<IEnumerable<Attendance>> GetAttendanceByStudentIdAsync_absents(int StudentID);
            Task<IEnumerable<Attendance>> GetAttendanceByClassNameAsync_absents(string ClassName);
            Task<IEnumerable<Attendance>> GetAttendanceBySessionIdAsync_absents(int SessionID);
            Task<IEnumerable<Attendance>> GetAttendanceByDateRangeAsync_absents(DateOnly From, DateOnly To);
            Task<IEnumerable<Attendance>> GetAttendanceByDateAsync_absents(DateOnly Date);

        }
    
}
