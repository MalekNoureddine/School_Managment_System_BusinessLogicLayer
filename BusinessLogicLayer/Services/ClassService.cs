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
    public class ClassesService : Service<Class>, IclassesService
    {
        private readonly Iclasses _classRepository;

        public ClassesService(Iclasses classRepository, IValidator<Class> validator) :
            base(classRepository, validator)
        {
            _classRepository = classRepository;
        }

        /// <summary>
        /// Retrieves a class by its name.
        /// </summary>
        /// <param name="className">The name of the class.</param>
        /// <returns>The class associated with the specified name.</returns>
        /// <exception cref="ArgumentException">Thrown when the class name is null or empty.</exception>
        public async Task<Class> GetByNameAsync(string className)
        {
            if (string.IsNullOrWhiteSpace(className))
            {
                throw new ArgumentException("Class name cannot be null or empty.", nameof(className));
            }

            return await _classRepository.GetByNameAsync(className);
        }

        /// <summary>
        /// Retrieves classes by grade level name.
        /// </summary>
        /// <param name="gradeLevelName">The name of the grade level.</param>
        /// <returns>A collection of classes associated with the specified grade level name.</returns>
        /// <exception cref="ArgumentException">Thrown when the grade level name is null or empty.</exception>
        public async Task<IEnumerable<Class>> GetClassesByGradeLevelAsync(string gradeLevelName)
        {
            if (string.IsNullOrWhiteSpace(gradeLevelName))
            {
                throw new ArgumentException("Grade level name cannot be null or empty.", nameof(gradeLevelName));
            }

            return await _classRepository.GetClassesByGradeLevelAsync(gradeLevelName);
        }

        /// <summary>
        /// Retrieves classes by grade level ID.
        /// </summary>
        /// <param name="gradeLevelID">The ID of the grade level.</param>
        /// <returns>A collection of classes associated with the specified grade level ID.</returns>
        /// <exception cref="ArgumentException">Thrown when the grade level ID is less than or equal to zero.</exception>
        public async Task<IEnumerable<Class>> GetClassesByGradeLevelAsync(int gradeLevelID)
        {
            if (gradeLevelID <= 0)
            {
                throw new ArgumentException("Grade level ID must be a positive integer.", nameof(gradeLevelID));
            }

            return await _classRepository.GetClassesByGradeLevelAsync(gradeLevelID);
        }

        
}
}


