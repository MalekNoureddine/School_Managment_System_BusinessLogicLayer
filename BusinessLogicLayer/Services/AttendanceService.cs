using BusinessLogicLayer.Services.Interfaces;
using BusinessLogicLayer.Validations;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using School_Managment_System1.Entities;
using School_Managment_System1.InterFaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BusinessLogicLayer.Services
{
    /// <summary>
    /// Service class for managing Attendance-related operations.
    /// </summary>
    public class AttendanceService : Service<Attendance>, IAttendanceService
    {
        private readonly IAttendances _attendanceRepository;
        private readonly IValidator<Attendance> _attendanceValidator;

        /// <summary>
        /// Initializes a new instance of the AttendanceService.
        /// </summary>
        /// <param name="attendanceRepository">The repository for attendance operations.</param>
        public AttendanceService(IAttendances attendanceRepository, IValidator<Attendance> attendanceValidator) : base (attendanceRepository, attendanceValidator)
        {
            _attendanceRepository = attendanceRepository;
            _attendanceValidator = attendanceValidator;
        }

        /// <summary>
        /// Get Attendance record by its ID.
        /// </summary>
        /// <param name="id">The attendance ID.</param>
        /// <returns>An attendance record.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the ID is not valid.</exception>
        public async Task<Attendance> GetAttendanceByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Invalid attendance ID.");
            }

            return await _attendanceRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Get Attendance records by student ID.
        /// </summary>
        /// <param name="studentId">The student ID.</param>
        /// <returns>List of attendance records for the student.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the student ID is not valid.</exception>
        public async Task<IEnumerable<Attendance>> GetAttendanceByStudentIdAsync(int studentId)
        {
            if (studentId <= 0)
            {
                throw new ArgumentOutOfRangeException("Invalid student ID.");
            }

            return await _attendanceRepository.GetByStudentIdAsync(studentId);
        }

        /// <summary>
        /// Retrieves the attendance records for a specific class.
        /// </summary>
        /// <param name="className">The name of the class for which to retrieve attendance records.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains a collection of attendance records for the specified class.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when the class name is null, empty, or consists only of white-space characters.</exception>
        public async Task<IEnumerable<Attendance>> GetAttendanceByClassNameAsync(string className)
        {
            if (string.IsNullOrWhiteSpace(className))
            {
                throw new ArgumentException("Class name cannot be empty.");
            }

            return await _attendanceRepository.GetByClassNameAsync(className);
        }

        /// <summary>
        /// Retrieves the attendance records for a specific session by session ID.
        /// </summary>
        /// <param name="sessionId">The ID of the session for which to retrieve attendance records.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains a collection of attendance records for the specified session.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the session ID is less than or equal to zero.</exception>

        public async Task<IEnumerable<Attendance>> GetAttendanceBySessionIdAsync(int sessionId)
        {
            if (sessionId <= 0)
            {
                throw new ArgumentOutOfRangeException("Invalid session ID.");
            }

            return await _attendanceRepository.GetBySessionIdAsync(sessionId);
        }

        /// <summary>
        /// Retrieves attendance records within a specified date range.
        /// </summary>
        /// <param name="from">The start date of the range.</param>
        /// <param name="to">The end date of the range.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains a collection of attendance records within the specified date range.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the start date is later than the end date or if the end date is later than today's date.
        /// </exception>
        public async Task<IEnumerable<Attendance>> GetAttendanceByDateRangeAsync(DateOnly from, DateOnly to)
        {
            if (from > to)
            {
                throw new ArgumentOutOfRangeException("Start date cannot be later than the end date.");
            }
            else if (to.ToDateTime(TimeOnly.MinValue) > DateTime.Today)
            {
                throw new ArgumentOutOfRangeException("End date cannot be later than Today.");
            }

            return await _attendanceRepository.GetByDateRangeAsync(from, to);
        }

        /// <summary>
        /// Retrieves attendance records for a specific date.
        /// </summary>
        /// <param name="date">The date for which attendance records are being retrieved.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains a collection of attendance records for the specified date.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the provided date is later than today's date.
        /// </exception>
        public async Task<IEnumerable<Attendance>> GetAttendanceByDateAsync(DateOnly date)
        {
            if (date.ToDateTime(TimeOnly.MinValue) > DateTime.Today)
            {
                throw new ArgumentOutOfRangeException("End date cannot be later than Today.");
            }
            return await _attendanceRepository.GetByDateAsync(date);
        }

        /// <summary>
        /// Retrieves attendance records for a specific student where the student was marked as present.
        /// </summary>
        /// <param name="studentId">The ID of the student for whom attendance records are being retrieved.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains a collection of attendance records where the student was present.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the provided student ID is less than or equal to 0.
        /// </exception>
        public async Task<IEnumerable<Attendance>> GetAttendanceByStudentIdAsync_presents(int studentId)
        {
            if (studentId <= 0)
            {
                throw new ArgumentOutOfRangeException("Invalid student ID.");
            }

            return await _attendanceRepository.GetByStudentIdAsync_presents(studentId);
        }

        /// <summary>
        /// Retrieves the attendance records of a student identified by their ID, specifically filtering for absences.
        /// </summary>
        /// <param name="studentId">The ID of the student whose attendance records are to be retrieved. Must be a positive integer.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IEnumerable{Attendance}"/> 
        /// containing the attendance records for the specified student that indicate absences.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="studentId"/> is less than or equal to zero.</exception>

        public async Task<IEnumerable<Attendance>> GetAttendanceByStudentIdAsync_absents(int studentId)
        {
            if (studentId <= 0)
            {
                throw new ArgumentOutOfRangeException("Invalid student ID.");
            }

            return await _attendanceRepository.GetByStudentIdAsync_absents(studentId);
        }




        /// <summary>
        /// Retrieves the attendance records of present students for a specific class.
        /// </summary>
        /// <param name="ClassName">The name of the class for which to retrieve attendance records.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains a collection of attendance records for present students in the specified class.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when the class name is null, empty, or consists only of white-space characters.</exception>

        public async Task<IEnumerable<Attendance>> GetAttendanceByClassNameAsync_presents(string ClassName)
        {
            if (string.IsNullOrWhiteSpace(ClassName))
            {
                throw new ArgumentException("Class name cannot be empty.");
            }

            return await _attendanceRepository.GetByClassNameAsync_presents(ClassName);
        }
        ///// <summary>
        ///// Marks attendance for a student by adding a new attendance record.
        ///// </summary>
        ///// <param name="attendance">The attendance entity containing attendance details (e.g., student ID, class, session, date).</param>
        ///// <returns>A task that represents the asynchronous operation of adding the attendance record to the repository.</returns>
        ///// <exception cref="ArgumentNullException">Thrown when the attendance object is null.</exception>

        //public async Task MarkAttendanceAsync(Attendance attendance)
        //{
        //    if (attendance == null)
        //        throw new ArgumentNullException(nameof(attendance));
        //    else
        //    await _attendanceRepository.AddAsync(attendance);
        //}

        ///// <summary>
        ///// Deletes the specified attendance record from the repository.
        ///// </summary>
        ///// <param name="attendance">The attendance record to be deleted. Must not be null.</param>
        ///// <exception cref="ArgumentNullException">Thrown when <paramref name="attendance"/> is null.</exception>
        //public void DeleteAttendance(Attendance attendance)
        //{
        //    if (attendance != null)
        //    {
        //        _attendanceRepository.Delete(attendance);
        //    }

        //}

        ///// <summary>
        ///// Deletes the attendance record with the specified ID asynchronously.
        ///// </summary>
        ///// <param name="attendanceId">The ID of the attendance record to be deleted. Must be greater than zero.</param>
        ///// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="attendanceId"/> is less than or equal to zero.</exception>
        ///// <exception cref="KeyNotFoundException">Thrown when an attendance record with the specified ID does not exist.</exception>

        //public async Task DeleteAttendanceByIdAsync(int attendanceId)
        //{
        //    if (attendanceId <= 0)
        //    {
        //        throw new ArgumentOutOfRangeException("Invalid attendance ID.");
        //    }
        //    var attendance = await _attendanceRepository.GetByIdAsync(attendanceId);
        //    if (attendance != null)
        //    {
        //        _attendanceRepository.Delete(attendance);
        //    }
        //    else
        //    {
        //        throw new KeyNotFoundException($"No attendance record found with ID {attendanceId}.");
        //    }
        //}

        /// <summary>
        /// Retrieves all attendance records asynchronously.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation, containing a collection of <see cref="Attendance"/> records.
        /// </returns>

        public async Task<IEnumerable<Attendance>> GetAllAttendancesAsync()
        {
            return await _attendanceRepository.GetAllAsync();
        }

        ///// <summary>
        ///// Updates the specified attendance record.
        ///// </summary>
        ///// <param name="attendance">The attendance object containing updated information.</param>
        ///// <exception cref="ArgumentNullException">Thrown when the attendance object is null.</exception>
        //public async Task UpdateAttendanceAsync(Attendance attendance)
        //{
        //    if (attendance == null)
        //        throw new ArgumentNullException(nameof(attendance), " cannot be null");
        //    else
        //        await _attendanceRepository.UpdateAsync(attendance);
                
        //}

        

        public async Task<IEnumerable<Attendance>> GetAttendanceBySessionIdAsync_presents(int SessionID)
        {
            if (SessionID <= 0)
            {
                throw new ArgumentException("Invalid session ID.");
            }

            return await _attendanceRepository.GetBySessionIdAsync_presents(SessionID);
        }

        /// <summary>
        /// Retrieves attendance records for the specified session that are marked as present.
        /// </summary>
        /// <param name="SessionID">The ID of the session for which to retrieve attendance records.</param>
        /// <returns>A task that represents the asynchronous operation, containing a collection of attendance records marked as present for the specified session.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <paramref name="SessionID"/> is less than or equal to zero.</exception>
        public async Task<IEnumerable<Attendance>> GetAttendanceByDateRangeAsync_presents(DateOnly from, DateOnly to)
        {
            if (from > to)
            {
                throw new ArgumentOutOfRangeException("Start date cannot be later than the end date.");
            }
            else if (to.ToDateTime(TimeOnly.MinValue) > DateTime.Today)
            {
                throw new ArgumentException("End date cannot be later than Today.");
            }

            return await _attendanceRepository.GetByDateRangeAsync_presents(from, to);
        }

        /// <summary>
        /// Retrieves attendance records marked as present for the specified date.
        /// </summary>
        /// <param name="date">The date for which to retrieve attendance records.</param>
        /// <returns>A task that represents the asynchronous operation, containing a collection of attendance records marked as present for the specified date.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <paramref name="date"/> is later than today.</exception>
        public async Task<IEnumerable<Attendance>> GetAttendanceByDateAsync_presents(DateOnly date)
        {
            if (date.ToDateTime(TimeOnly.MinValue) > DateTime.Today)
            {
                throw new ArgumentOutOfRangeException("End date cannot be later than Today.");
            }
            return await _attendanceRepository.GetByDateAsync_presents(date);
        }

        /// <summary>
        /// Retrieves attendance records marked as absent for the specified class name.
        /// </summary>
        /// <param name="ClassName">The name of the class for which to retrieve attendance records.</param>
        /// <returns>A task that represents the asynchronous operation, containing a collection of attendance records marked as absent for the specified class name.</returns>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="ClassName"/> is null, empty, or consists only of white-space characters.</exception>
        public async Task<IEnumerable<Attendance>> GetAttendanceByClassNameAsync_absents(string ClassName)
        {
            if (string.IsNullOrWhiteSpace(ClassName))
            {
                throw new ArgumentException("Class name cannot be empty.");
            }

            return await _attendanceRepository.GetByClassNameAsync_absents(ClassName);
        }

        /// <summary>
        /// Retrieves attendance records marked as absent for the specified session ID.
        /// </summary>
        /// <param name="SessionID">The ID of the session for which to retrieve attendance records marked as absent.</param>
        /// <returns>A task that represents the asynchronous operation, containing a collection of attendance records marked as absent for the specified session ID.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <paramref name="SessionID"/> is less than or equal to zero.</exception>
        public async Task<IEnumerable<Attendance>> GetAttendanceBySessionIdAsync_absents(int SessionID)
        {
            if (SessionID <= 0)
            {
                throw new ArgumentOutOfRangeException("Invalid session ID.");
            }

            return await _attendanceRepository.GetBySessionIdAsync_absents(SessionID);
        }

        /// <summary>
        /// Retrieves attendance records marked as absent within the specified date range.
        /// </summary>
        /// <param name="from">The start date of the range for which to retrieve attendance records marked as absent.</param>
        /// <param name="to">The end date of the range for which to retrieve attendance records marked as absent.</param>
        /// <returns>A task that represents the asynchronous operation, containing a collection of attendance records marked as absent within the specified date range.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the <paramref name="from"/> date is later than the <paramref name="to"/> date, or when the <paramref name="to"/> date is later than today.
        /// </exception>
        public async Task<IEnumerable<Attendance>> GetAttendanceByDateRangeAsync_absents(DateOnly from, DateOnly to)
        {
            if (from > to)
            {
                throw new ArgumentOutOfRangeException("Start date cannot be later than the end date.");
            }
            else if (to.ToDateTime(TimeOnly.MinValue) > DateTime.Today)
            {
                throw new ArgumentOutOfRangeException("End date cannot be later than Today.");
            }

            return await _attendanceRepository.GetByDateRangeAsync_absents(from, to);
        }


        /// <summary>
        /// Retrieves attendance records marked as absent for a specific date.
        /// </summary>
        /// <param name="date">The date for which to retrieve attendance records marked as absent.</param>
        /// <returns>A task that represents the asynchronous operation, containing a collection of attendance records marked as absent for the specified date.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the <paramref name="date"/> is later than today.
        /// </exception>
        public async Task<IEnumerable<Attendance>> GetAttendanceByDateAsync_absents(DateOnly date)
        {
            if (date.ToDateTime(TimeOnly.MinValue) > DateTime.Today)
            {
                throw new ArgumentOutOfRangeException("End date cannot be later than Today.");
            }
            return await _attendanceRepository.GetByDateAsync_absents(date);
        }

        //// </summary>
        ///// <param name="attendance">The attendance record to be added. It must not be null.</param>
        ///// <exception cref="ArgumentNullException">
        ///// Thrown when the <paramref name="attendance"/> is null.
        ///// </exception>
        //public void MarkAttendance(Attendance attendance)
        //{
        //    if (attendance != null)
        //        _attendanceRepository.Add(attendance);
        //    else
        //        throw new ArgumentNullException(nameof(attendance), "Attendance record cannot be null.");
        //}

        ///// <summary>
        ///// Marks the attendance for multiple students by adding a range of attendance records.
        ///// </summary>
        ///// <param name="attendances">A list of attendance records to be added. It must not be null or empty.</param>
        ///// <exception cref="ArgumentException">
        ///// Thrown when the <paramref name="attendances"/> list is null or empty.
        ///// </exception>
        //public async Task MarkAttendanceRangeAsync(List<Attendance> attendances)
        //{
        //    if (!attendances.IsNullOrEmpty())
        //        await _attendanceRepository.AddRangeAsync(attendances);
        //    else
        //        throw new ArgumentException("Attendance list cannot be null or empty.", nameof(attendances));
        //}

        ///// <summary>
        ///// Marks the attendance for multiple students by adding a range of attendance records.
        ///// </summary>
        ///// <param name="attendances">A list of attendance records to be added. It must not be null or empty.</param>
        ///// <exception cref="ArgumentException">
        ///// Thrown when the <paramref name="attendances"/> list is null or empty.
        ///// </exception>
        ///// <remarks>
        ///// This method does not await the asynchronous operation of adding attendance records.
        ///// Ensure that the calling code handles the operation appropriately.
        ///// </remarks>
        //public void MarkAttendanceRange(List<Attendance> attendances)
        //{
        //    if (!attendances.IsNullOrEmpty())
        //        _attendanceRepository.AddRangeAsync(attendances);
        //    else
        //        throw new ArgumentException("Attendance list cannot be null or empty.", nameof(attendances));
        //}


        ///// <summary>
        ///// Updates an existing attendance record.
        ///// </summary>
        ///// <param name="attendance">The attendance record to be updated. It must not be null.</param>
        ///// <exception cref="ArgumentNullException">
        ///// Thrown when the <paramref name="attendance"/> is null.
        ///// </exception>
        ///// <remarks>
        ///// This method assumes that the provided attendance record exists in the repository.
        ///// If the record does not exist, the update operation may not have any effect.
        ///// </remarks>
        //public void UpdateAttendance(Attendance attendance)
        //{
        //    if (attendance != null)
        //        _attendanceRepository.Update(attendance);
        //    else
        //        throw new ArgumentNullException(nameof(attendance), "Attendance cannot be null.");
        //}
    }

}
