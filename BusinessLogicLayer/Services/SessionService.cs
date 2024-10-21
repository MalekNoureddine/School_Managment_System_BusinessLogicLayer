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
    public class SessionsService : Service<Session>, ISessionsService
    {
        private readonly ISessions _sessionsRepository;

        public SessionsService(ISessions sessionsRepository, IValidator<Session> validator)
            : base(sessionsRepository, validator)
        {
            _sessionsRepository = sessionsRepository;
        }

        /// <summary>
        /// Retrieves a session by its ID.
        /// </summary>
        /// <param name="sessionID">The ID of the session.</param>
        /// <returns>The session with the specified ID, or null if not found.</returns>
        /// <exception cref="ArgumentException">Thrown when the session ID is less than or equal to zero.</exception>
        public async Task<Session> GetByIDAsync(int sessionID)
        {
            if (sessionID <= 0)
            {
                throw new ArgumentException("Session ID must be a positive integer.", nameof(sessionID));
            }

            return await _sessionsRepository.GetByIDAsync(sessionID);
        }

        /// <summary>
        /// Retrieves all sessions for a given class subject ID.
        /// </summary>
        /// <param name="classSubjectId">The ID of the class subject.</param>
        /// <returns>A list of sessions for the class subject, or an empty list if none found.</returns>
        /// <exception cref="ArgumentException">Thrown when the class subject ID is less than or equal to zero.</exception>
        public async Task<IEnumerable<Session>> GetByClassSubjectIdAsync(int classSubjectId)
        {
            if (classSubjectId <= 0)
            {
                throw new ArgumentException("Class Subject ID must be a positive integer.", nameof(classSubjectId));
            }

            return await _sessionsRepository.GetByClassSubjectIdAsync(classSubjectId);
        }

        /// <summary>
        /// Retrieves all sessions that are scheduled on a specific date.
        /// </summary>
        /// <param name="date">The date of the session.</param>
        /// <returns>A list of sessions scheduled on the given date, or an empty list if none found.</returns>
        public async Task<IEnumerable<Session>> GetByDateAsync(DateOnly date)
        {
            return await _sessionsRepository.GetByDateAsync(date);
        }

        /// <summary>
        /// Retrieves all sessions that start at a specific time.
        /// </summary>
        /// <param name="startAt">The start time of the session.</param>
        /// <returns>A list of sessions starting at the specified time, or an empty list if none found.</returns>
        public async Task<IEnumerable<Session>> GetByStartTimeAsync(TimeOnly startAt)
        {
            return await _sessionsRepository.GetByStartTimeAsync(startAt);
        }

        /// <summary>
        /// Retrieves all sessions that end at a specific time.
        /// </summary>
        /// <param name="endsAt">The end time of the session.</param>
        /// <returns>A list of sessions ending at the specified time, or an empty list if none found.</returns>
        public async Task<IEnumerable<Session>> GetByEndingTimeAsync(TimeOnly endsAt)
        {
            return await _sessionsRepository.GetByEndingTimeAsync(endsAt);
        }

        /// <summary>
        /// Retrieves all sessions within a specific time range.
        /// </summary>
        /// <param name="startsAt">The start time of the session.</param>
        /// <param name="endsAt">The end time of the session.</param>
        /// <returns>A list of sessions within the specified time range, or an empty list if none found.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the start time is after the end time.</exception>
        public async Task<IEnumerable<Session>> GetByTimeAsync(TimeOnly startsAt, TimeOnly endsAt)
        {
            if (startsAt > endsAt)
            {
                throw new ArgumentOutOfRangeException("Start time cannot be later than end time.", nameof(startsAt));
            }

            return await _sessionsRepository.GetByTimeAsync(startsAt, endsAt);
        }

    }

}
