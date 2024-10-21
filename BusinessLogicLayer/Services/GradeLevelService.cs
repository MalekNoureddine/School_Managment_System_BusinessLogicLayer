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
public class GradeLevelsService : Service<GradeLevel>, IGradeLevelsService
    {
        private readonly IGradeLevels _gradeLevelsRepository;

        public GradeLevelsService(IGradeLevels gradeLevelsRepository, IValidator<GradeLevel> validator)
            : base(gradeLevelsRepository, validator)
        {
            _gradeLevelsRepository = gradeLevelsRepository;
        }

        /// <summary>
        /// Retrieves a grade level by its ID.
        /// </summary>
        /// <param name="id">The ID of the grade level.</param>
        /// <returns>The grade level with the specified ID.</returns>
        /// <exception cref="ArgumentException">Thrown when the grade level ID is less than or equal to zero.</exception>
        public async Task<GradeLevel> GetByIDAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be a positive integer.", nameof(id));
            }

            return await _gradeLevelsRepository.GetByIDAsync(id);
        }

        /// <summary>
        /// Retrieves a grade level by its name.
        /// </summary>
        /// <param name="name">The name of the grade level.</param>
        /// <returns>The grade level with the specified name.</returns>
        /// <exception cref="ArgumentException">Thrown when the name is null, empty, or whitespace.</exception>
        public async Task<GradeLevel> GetByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Grade level name cannot be null, empty, or whitespace.", nameof(name));
            }

            return await _gradeLevelsRepository.GetByNameAsync(name);
            
        }
    }

}
