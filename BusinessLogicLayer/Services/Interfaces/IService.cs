using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        void Add(T entity);
        void AddRange(List<T> entities);
        void Update(T entity);
        Task UpdateAsync(T entity);
        void Delete(T entity);
        void DeleteRange(List<T> entity);
    }
}
