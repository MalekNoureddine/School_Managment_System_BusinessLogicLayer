using Microsoft.EntityFrameworkCore;
using School_Managment_System1.Data;
using School_Managment_System1.Entities;
using School_Managment_System1.InterFaces.IRepositories;
using School_Managment_System1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class SubjectsRepository : Repository<Subject>, ISubjects
    {
        private readonly AppDbContext _context;

        public SubjectsRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a subject by its ID.
        /// </summary>
        /// <param name="subjectId">The ID of the subject.</param>
        /// <returns>The subject with the specified ID, or null if not found.</returns>
        public async Task<Subject> GetByIdAsync(int subjectId)
        {
            if (subjectId <= 0)
            {
                throw new ArgumentException("Subject ID must be a positive integer.", nameof(subjectId));
            }

            return await _context.Subjects.FindAsync(subjectId);
        }

        /// <summary>
        /// Retrieves a subject by its name.
        /// </summary>
        /// <param name="subjectName">The name of the subject.</param>
        /// <returns>The subject with the specified name, or null if not found.</returns>
        public async Task<Subject> GetByNameAsync(string subjectName)
        {
            if (string.IsNullOrWhiteSpace(subjectName))
            {
                throw new ArgumentException("Subject name must not be empty.", nameof(subjectName));
            }

            return await _context.Subjects
                .FirstOrDefaultAsync(s => s.SubjectName.Equals(subjectName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
