using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using School.Domain.Consts;
using School.Domain.IGenericRepository_IUOW;
using School.Infrastructure.Data;
using System.Linq.Expressions;

namespace School.Infrastructure.GenericRepository_UOW
{
    public class GenericRepository<T>(ApplicationDBContext dbContext) : IGenericRepository<T> where T : class
    {
        #region fields

        protected readonly ApplicationDBContext _dbContext = dbContext;

        #endregion

        #region methods

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, object>> orderBy = null, string direction = null, List<Expression<Func<T, object>>> includes = null)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (orderBy != null)
            {
                if (direction == OrderDirection.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsNoTrackingAsync(Expression<Func<T, object>> orderBy = null, string direction = null, List<Expression<Func<T, object>>> includes = null)
        {
            IQueryable<T> query = _dbContext.Set<T>().AsNoTracking();

            if (orderBy != null)
            {
                if (direction == OrderDirection.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.ToListAsync();
        }

        public async Task<T> FindFirstAsync(Expression<Func<T, bool>> expression, List<Expression<Func<T, object>>> includes = null)
        {
            IQueryable<T> query = _dbContext.Set<T>().Where(expression);

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.FirstOrDefaultAsync();
        }



        public async Task<IEnumerable<T>> FindAsNoTrackingAsync(Expression<Func<T, bool>> expression, Expression<Func<T, object>>? orderBy = null, string direction = null, List<Expression<Func<T, object>>> includes = null)
        {
            IQueryable<T> query = _dbContext.Set<T>().Where(expression).AsNoTracking();

            if (orderBy != null)
            {
                if (direction == OrderDirection.Descending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.ToListAsync();
        }


        public async Task AddRangeAsync(ICollection<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Attach(entity);
            _dbContext.Entry<T>(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }
        public async Task DeleteRangeAsync(ICollection<T> entities)
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

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression, Expression<Func<T, object>>? orderBy = null, string direction = null, List<Expression<Func<T, object>>> includes = null)
        {
            IQueryable<T> query = _dbContext.Set<T>().Where(expression);

            if (orderBy != null)
            {
                if (direction == OrderDirection.Descending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.ToListAsync();
        }

        public async Task UpdateRangeAsync(ICollection<T> entities)
        {
            _dbContext.Set<T>().UpdateRange(entities);
        }

        public async Task<bool> IsExsist(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(expression) != null;
        }
        #endregion
    }
}
