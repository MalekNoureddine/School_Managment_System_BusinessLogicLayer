using School_Managment_System1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    internal interface IStudentService : IService<Student>
    {
        Task<Student> GetByIDAsync(int StudentID);
        Task<IEnumerable<Student>> GetByParentIDAsync(int ParentID);
        Task<IEnumerable<Student>> GetByClassNameAsync(string ClassName);
        Task<IEnumerable<Student>> GetByFirstNameAsync(string FirstName);
        Task<IEnumerable<Student>> GeByLastNameAsync(string LastName);
        Task<IEnumerable<Student>> GetByFullNameAsync(string FirstName, string LastName);
        Task<IEnumerable<Student>> GetByDateOfBirthAsync(DateOnly DateOfBirth);
    }
}
