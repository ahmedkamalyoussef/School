using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using School.Infrastructure.Data;
using School.Domain.IGenericRepository_IUOW;
using System.Linq.Expressions;

namespace School.Infrastructure.GenericRepository_UOW
{
    public class GenericRepository<T>(ApplicationDBContext dbContext) : IGenericRepository<T> where T : class
    {
        #region fields

        protected readonly ApplicationDBContext _dbContext = dbContext;

        #endregion

        #region methods
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }


        public IQueryable<T> GetTableNoTracking(List<Expression<Func<T, object>>> includes = null)
        {
            IQueryable<T> query = _dbContext.Set<T>().AsNoTracking().AsQueryable();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query;
        }


        public virtual async Task AddRangeAsync(ICollection<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
        }
        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }
        public virtual async Task DeleteRangeAsync(ICollection<T> entities)
        {
            foreach (var entity in entities)
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }
        }

        



        public IDbContextTransaction BeginTransaction()
        {


            return _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _dbContext.Database.CommitTransaction();

        }

        public void RollBack()
        {
            _dbContext.Database.RollbackTransaction();

        }

        public IQueryable<T> GetTableAsTracking(List<Expression<Func<T, object>>> includes = null)
        {
            IQueryable<T> query = _dbContext.Set<T>().AsQueryable();
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query;
        }

        public virtual async Task UpdateRangeAsync(ICollection<T> entities)
        {
            _dbContext.Set<T>().UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}
