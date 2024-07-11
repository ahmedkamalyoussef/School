using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace School.Domain.IGenericRepository_IUOW
{
    public interface IGenericRepository<T> where T : class
    {
        Task DeleteRangeAsync(ICollection<T> entities);
        Task<T> GetByIdAsync(int id);
        IDbContextTransaction BeginTransaction();
        void Commit();
        void RollBack();
        IQueryable<T> GetTableNoTracking(List<Expression<Func<T, object>>> includes = null);
        IQueryable<T> GetTableAsTracking(List<Expression<Func<T, object>>> includes = null);
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(ICollection<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);
        Task DeleteAsync(T entity);
    }
}
