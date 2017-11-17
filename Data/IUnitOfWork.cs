using System;

namespace Data
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();

        IRepository<TEntity> Repository<TEntity>()
            where TEntity : class;
    }
}
