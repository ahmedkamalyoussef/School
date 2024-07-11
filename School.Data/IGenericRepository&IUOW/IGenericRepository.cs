using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace School.Domain.IGenericRepository_IUOW
{
    public interface IGenericRepository<T> where T : class
    {
        Task DeleteRangeAsync(ICollection<T> entities);
        Task<T> FindFirstAsync(Expression<Func<T, bool>> expression, List<Expression<Func<T, object>>> includes = null);
        IDbContextTransaction BeginTransaction();
        void Commit();
        void RollBack();
        Task<IEnumerable<T>> GetAllAsNoTrackingAsync(Expression<Func<T, object>> orderBy = null, string direction = null, List<Expression<Func<T, object>>> includes = null);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, object>> orderBy = null, string direction = null, List<Expression<Func<T, object>>> includes = null);
        Task<IEnumerable<T>> FindAsNoTrackingAsync(Expression<Func<T, bool>> expression, Expression<Func<T, object>>? orderBy = null, string direction = null, List<Expression<Func<T, object>>> includes = null);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression, Expression<Func<T, object>>? orderBy = null, string direction = null, List<Expression<Func<T, object>>> includes = null);
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(ICollection<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);
        Task DeleteAsync(T entity);
    }
}
