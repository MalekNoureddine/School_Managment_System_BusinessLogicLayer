using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    using FluentValidation;
    using School_Managment_System1.Entities;
    using School_Managment_System1.InterFaces.IRepositories;
    using School_Managment_System1.Repositories;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    public class ClassesSchedulesService : Service<ClassSchedule>, IClassesSchedulesService
    {
        private readonly IClassesSchedules _classScheduleRepository;

        public ClassesSchedulesService(IClassesSchedules classScheduleRepository, IValidator<ClassSchedule> validator)
            : base(classScheduleRepository, validator)
        {
            _classScheduleRepository = classScheduleRepository;
        }

        /// <summary>
        /// Retrieves a class schedule by its ID.
        /// </summary>
        /// <param name="id">The ID of the class schedule.</param>
        /// <returns>The class schedule associated with the specified ID.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when the class schedule is not found.</exception>
        public async Task<ClassSchedule> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be a positive integer.", nameof(id));
            }

            var classSchedule = await _classScheduleRepository.GetByIdAsync(id);
            if (classSchedule == null)
            {
                throw new KeyNotFoundException($"Class schedule with ID {id} not found.");
            }
            return classSchedule;
        }

        /// <summary>
        /// Retrieves class schedules by subject ID.
        /// </summary>
        /// <param name="subjectId">The ID of the subject.</param>
        /// <returns>A collection of class schedules associated with the specified subject ID.</returns>
        /// <exception cref="ArgumentException">Thrown when the subject ID is invalid.</exception>
        public async Task<IEnumerable<ClassSchedule>> GetBySubjectIdAsync(int subjectId)
        {
            if (subjectId <= 0)
            {
                throw new ArgumentException("Subject ID must be a positive integer.", nameof(subjectId));
            }

            return await _classScheduleRepository.GetBySubjectIdAsync(subjectId);
        }

        /// <summary>
        /// Retrieves class schedules that start at a specified time.
        /// </summary>
        /// <param name="startAt">The start time to filter class schedules.</param>
        /// <returns>A collection of class schedules that start at the specified time.</returns>
        public async Task<IEnumerable<ClassSchedule>> GetByStartTimeAsync(TimeOnly startAt)
        {
            return await _classScheduleRepository.GetByStartTimeAsync(startAt);
        }

        /// <summary>
        /// Retrieves class schedules that end at a specified time.
        /// </summary>
        /// <param name="endsAt">The end time to filter class schedules.</param>
        /// <returns>A collection of class schedules that end at the specified time.</returns>
        public async Task<IEnumerable<ClassSchedule>> GetByEndingTimeAsync(TimeOnly endsAt)
        {
            return await _classScheduleRepository.GetByEndingTimeAsync(endsAt);
        }

        /// <summary>
        /// Retrieves class schedules that start and end within a specified time range.
        /// </summary>
        /// <param name="startsAt">The start time of the range.</param>
        /// <param name="endsAt">The end time of the range.</param>
        /// <returns>A collection of class schedules within the specified time range.</returns>
        /// <exception cref="ArgumentException">Thrown when the start time is after the end time.</exception>
        public async Task<IEnumerable<ClassSchedule>> GetByTimeAsync(TimeOnly startsAt, TimeOnly endsAt)
        {
            if (startsAt > endsAt)
            {
                throw new ArgumentException("Start time cannot be after end time.");
            }

            return await _classScheduleRepository.GetByTimeAsync(startsAt, endsAt);
        }

        /// <summary>
        /// Retrieves class schedules by class name.
        /// </summary>
        /// <param name="className">The name of the class.</param>
        /// <returns>A collection of class schedules associated with the specified class name.</returns>
        /// <exception cref="ArgumentException">Thrown when the class name is null or empty.</exception>
        public async Task<IEnumerable<ClassSchedule>> GetByNameAsync(string className)
        {
            if (string.IsNullOrWhiteSpace(className))
            {
                throw new ArgumentException("Class name cannot be null or empty.", nameof(className));
            }

            return await _classScheduleRepository.GetByNameAsync(className);
        }

        /// <summary>
        /// Retrieves class schedules for a specific day of the week.
        /// </summary>
        /// <param name="dayOfWeek">The day of the week (e.g., "Monday").</param>
        /// <returns>A collection of class schedules for the specified day of the week.</returns>
        /// <exception cref="ArgumentException">Thrown when the day of the week is null or empty.</exception>
        public async Task<IEnumerable<ClassSchedule>> GetByDayOfTheWeekAsync(string dayOfWeek)
        {
            if (string.IsNullOrWhiteSpace(dayOfWeek))
            {
                throw new ArgumentException("Day of the week cannot be null or empty.", nameof(dayOfWeek));
            }

            return await _classScheduleRepository.GetByDayOfTheWeekAsync(dayOfWeek);
        }
    }


}
