using System;
using System.Linq;
using System.Linq.Expressions;

namespace Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> FindAll(params Expression<Func<TEntity, object>>[] navigations);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
