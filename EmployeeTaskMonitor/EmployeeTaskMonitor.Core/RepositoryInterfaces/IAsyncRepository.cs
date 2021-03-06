using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTaskMonitor.Core.RepositoryInterfaces
{
    public interface IAsyncRepository<T> where T: class
    {
        Task<T> GetByIdAsync(int Id);
        Task<IEnumerable<T>> ListAllAsync();
        Task<IEnumerable<T> >ListAsync(Expression<Func<T, bool>> filter);
        Task<int> GetCountAsync(Expression<Func<T, bool>> filter = null);
        Task<bool> GetExistsAsync(Expression<Func<T, bool>> filter = null);


        Task<T> AddAsync(T entity);


        Task<T> UpdateAsync(T entity);


        Task<T> DeleteAsync(T entity);
    }
}
