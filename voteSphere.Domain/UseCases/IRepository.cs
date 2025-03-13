using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace voteSphere.Domain.UseCases
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = true
        );

        T GetById(object id);
        Task<T> GetByIdAsync(object id);  // 🔹 Now correctly fetches by ID
        
        Task<T> GetByFilterAsync(  // 🔹 Added a separate filtering method
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = true
        );

        void Add(T entity);
        Task<T> AddAsync(T entity);

        void Update(T entity);
        Task<T> UpdateAsync(T entity);

        void Delete(T entity);
        Task<T> DeleteAsync(T entity);

        void DeleteRange(List<T> entities);
        Task DeleteRangeAsync(List<T> entities);  // 🔹 Added missing async version
    }
}
