using FluentValidation;
using School_Managment_System1.Entities;
using School_Managment_System1.InterFaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class TeachersSchedulesService : Service<TeacherSchedule>, ITeachersSchedulesService
    {
        private readonly ITeachersSchedules _teacherSchedulesRepository;

        public TeachersSchedulesService(ITeachersSchedules teacherSchedulesRepository, IValidator<TeacherSchedule> validator)
            : base(teacherSchedulesRepository, validator)
        {
            _teacherSchedulesRepository = teacherSchedulesRepository;
        }

        /// <summary>
        /// Retrieves a teacher schedule by its ID.
        /// </summary>
        /// <param name="id">The ID of the teacher schedule.</param>
        /// <returns>The teacher schedule with the specified ID, or null if not found.</returns>
        /// <exception cref="ArgumentException">Thrown when the ID is less than or equal to zero.</exception>
        public async Task<TeacherSchedule> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be a positive integer.", nameof(id));
            }

            return await _teacherSchedulesRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Retrieves teacher schedules by teacher ID.
        /// </summary>
        /// <param name="teacherId">The ID of the teacher.</param>
        /// <returns>A list of schedules associated with the specified teacher ID.</returns>
        /// <exception cref="ArgumentException">Thrown when the teacher ID is less than or equal to zero.</exception>
        public async Task<TeacherSchedule> GetByTeacherIdAsync(int teacherId)
        {
            if (teacherId <= 0)
            {
                throw new ArgumentException("Teacher ID must be a positive integer.", nameof(teacherId));
            }

            return await _teacherSchedulesRepository.GetByTeacherIdAsync(teacherId);
        }

        /// <summary>
        /// Retrieves teacher schedules by subject ID.
        /// </summary>
        /// <param name="subjectId">The ID of the subject.</param>
        /// <returns>A list of schedules associated with the specified subject ID.</returns>
        /// <exception cref="ArgumentException">Thrown when the subject ID is less than or equal to zero.</exception>
        public async Task<IEnumerable<TeacherSchedule>> GetBySubjectIdAsync(int subjectId)
        {
            if (subjectId <= 0)
            {
                throw new ArgumentException("Subject ID must be a positive integer.", nameof(subjectId));
            }

            return await _teacherSchedulesRepository.GetBySubjectIdAsync(subjectId);
        }

        /// <summary>
        /// Retrieves teacher schedules by subject and teacher ID.
        /// </summary>
        /// <param name="subjectId">The ID of the subject.</param>
        /// <param name="teacherId">The ID of the teacher.</param>
        /// <returns>A list of schedules associated with the specified subject and teacher ID.</returns>
        /// <exception cref="ArgumentException">Thrown when the subject ID or teacher ID is less than or equal to zero.</exception>
        public async Task<IEnumerable<TeacherSchedule>> GetBySubjectIdAndTeacherIdAsync(int subjectId, int teacherId)
        {
            if (subjectId <= 0 || teacherId <= 0)
            {
                throw new ArgumentException("Subject ID and Teacher ID must be positive integers.");
            }

            return await _teacherSchedulesRepository.GetBySubjectIdAndTeacherIdAsync(subjectId, teacherId);
        }

        /// <summary>
        /// Retrieves teacher schedules by subject, teacher ID, and class name.
        /// </summary>
        /// <param name="subjectId">The ID of the subject.</param>
        /// <param name="teacherId">The ID of the teacher.</param>
        /// <param name="className">The name of the class.</param>
        /// <returns>A list of schedules associated with the specified subject, teacher ID, and class name.</returns>
        /// <exception cref="ArgumentException">Thrown when the subject ID or teacher ID is less than or equal to zero, or when the class name is null or empty.</exception>
        public async Task<IEnumerable<TeacherSchedule>> GetBySubjectIdAndTeacherIdAndClassNameAsync(int subjectId, int teacherId, string className)
        {
            if (subjectId <= 0 || teacherId <= 0)
            {
                throw new ArgumentException("Subject ID and Teacher ID must be positive integers.");
            }

            if (string.IsNullOrWhiteSpace(className))
            {
                throw new ArgumentException("Class name must not be empty.", nameof(className));
            }

            return await _teacherSchedulesRepository.GetBySubjectIdAndTeacherIdAndClassNameAsync(subjectId, teacherId, className);
        }

        /// <summary>
        /// Retrieves teacher schedules by start time.
        /// </summary>
        /// <param name="startAt">The start time of the schedule.</param>
        /// <returns>A list of schedules starting at the specified time.</returns>
        public async Task<IEnumerable<TeacherSchedule>> GetByStartTimeAsync(TimeOnly startAt)
        {
            return await _teacherSchedulesRepository.GetByStartTimeAsync(startAt);
        }

        /// <summary>
        /// Retrieves teacher schedules by ending time.
        /// </summary>
        /// <param name="endsAt">The ending time of the schedule.</param>
        /// <returns>A list of schedules ending at the specified time.</returns>
        public async Task<IEnumerable<TeacherSchedule>> GetByEndingTimeAsync(TimeOnly endsAt)
        {
            return await _teacherSchedulesRepository.GetByEndingTimeAsync(endsAt);
        }

        /// <summary>
        /// Retrieves teacher schedules within a specific time range.
        /// </summary>
        /// <param name="startsAt">The start time of the schedule.</param>
        /// <param name="endsAt">The end time of the schedule.</param>
        /// <returns>A list of schedules within the specified time range.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the start time is after the end time.</exception>
        public async Task<IEnumerable<TeacherSchedule>> GetByTimeAsync(TimeOnly startsAt, TimeOnly endsAt)
        {
            if(startsAt > endsAt)
            {
                throw new ArgumentOutOfRangeException("Start time cannot be later than end time.", nameof(startsAt));
            }
            return await _teacherSchedulesRepository.GetByTimeAsync(startsAt, endsAt);
        }

        /// <summary>
        /// Retrieves teacher schedules by class name.
        /// </summary>
        /// <param name="className">The name of the class.</param>
        /// <returns>A list of schedules associated with the specified class name.</returns>
        /// <exception cref="ArgumentException">Thrown when the class name is null or empty.</exception>
        public async Task<IEnumerable<TeacherSchedule>> GetByNameAsync(string className)
        {
            if (string.IsNullOrWhiteSpace(className))
            {
                throw new ArgumentException("Class name must not be empty.", nameof(className));
            }

            return await _teacherSchedulesRepository.GetByNameAsync(className);
        }

        /// <summary>
        /// Retrieves teacher schedules by the day of the week.
        /// </summary>
        /// <param name="dayOfWeek">The day of the week.</param>
        /// <returns>A list of schedules for the specified day of the week.</returns>
        /// <exception cref="ArgumentException">Thrown when the day of the week is null or empty.</exception>
        public async Task<IEnumerable<TeacherSchedule>> GetByDayOfTheWeekAsync(string dayOfWeek)
        {
            if (string.IsNullOrWhiteSpace(dayOfWeek))
            {
                throw new ArgumentException("Day of the week must not be empty.", nameof(dayOfWeek));
            }

            return await _teacherSchedulesRepository.GetByDayOfTheWeekAsync(dayOfWeek);
        }
    }

}
