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
    public class ClassTeachersService : Service<ClassTeacher>, IClassTeacherService
    {
        private readonly IClassTechre _classTeacherRepository;

        public ClassTeachersService(IClassTechre classTeacherRepository, IValidator<ClassTeacher> validator)
            : base(classTeacherRepository, validator)
        {
            _classTeacherRepository = classTeacherRepository;
        }

        /// <summary>
        /// Retrieves a class teacher by their ID.
        /// </summary>
        /// <param name="id">The ID of the class teacher.</param>
        /// <returns>The class teacher associated with the specified ID.</returns>
        /// <exception cref="ArgumentException">Thrown when the ID is less than or equal to zero.</exception>
        public async Task<ClassTeacher> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be a positive integer.", nameof(id));
            }

            return await _classTeacherRepository.GetClassTeacherByIdAsync(id);
        }

        /// <summary>
        /// Retrieves class teachers by class name.
        /// </summary>
        /// <param name="className">The name of the class.</param>
        /// <returns>A collection of class teachers associated with the specified class name.</returns>
        /// <exception cref="ArgumentException">Thrown when the class name is null or empty.</exception>
        public async Task<IEnumerable<ClassTeacher>> GetByClassNameAsync(string className)
        {
            if (string.IsNullOrWhiteSpace(className))
            {
                throw new ArgumentException("Class name cannot be null or empty.", nameof(className));
            }

            return await _classTeacherRepository.GetClassTeacherByClassNameAsync(className);
        }

        /// <summary>
        /// Retrieves class teachers by teacher ID.
        /// </summary>
        /// <param name="teacherID">The ID of the teacher.</param>
        /// <returns>A collection of class teachers associated with the specified teacher ID.</returns>
        /// <exception cref="ArgumentException">Thrown when the teacher ID is less than or equal to zero.</exception>
        public async Task<IEnumerable<ClassTeacher>> GetByTeacherIDAsync(int teacherID)
        {
            if (teacherID <= 0)
            {
                throw new ArgumentException("Teacher ID must be a positive integer.", nameof(teacherID));
            }

            return await _classTeacherRepository.GetClassTeacherByTeacherIDAsync(teacherID);
        }
    }

}
