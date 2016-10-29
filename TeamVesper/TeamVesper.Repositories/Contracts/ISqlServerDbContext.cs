using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace TeamVesper.Repositories.Contracts
{
    public interface ISqlServerDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}
