using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Data
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> FindAll(params Expression<Func<TEntity, object>>[] navigations)
        {
            IQueryable<TEntity> query = _dbSet;

            if (navigations == null || navigations.Length == 0)
            {
                return _dbSet;
            }

            return navigations.Aggregate(query, (current, navigation) => current.Include(navigation)).AsNoTracking();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }
    }
}
