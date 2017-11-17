using System;
using System.Data.Entity;

namespace Data
{
    public class UnitOfWork<TContext> : IUnitOfWork
        where TContext : DbContext
    {
        private readonly DbContext _context;
        private bool _disposed;

        public UnitOfWork(TContext context)
        {
            _context = context;
            ConfigureContext(_context);
        }

        public void SaveChanges()
        {
            _context.ChangeTracker.DetectChanges();
            _context.SaveChanges();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            return new GenericRepository<TEntity>(_context);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        private static void ConfigureContext(DbContext context)
        {
            Database.SetInitializer<TContext>(null);

            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.LazyLoadingEnabled = false;
        }
    }
}
