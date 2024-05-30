using Survey.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();
        Task<List<T>> GetAll(Expression<Func<T, bool>> expression);
        Task<T> Find(Expression<Func<T, bool>> expression);
        Task<int> Create(T entity);
        Task<int> Update(T entity);
        Task<bool> Any(Expression<Func<T, bool>> expression);
        Task<int> Delete(T entity);
        Task<int> Save();
    }
}
