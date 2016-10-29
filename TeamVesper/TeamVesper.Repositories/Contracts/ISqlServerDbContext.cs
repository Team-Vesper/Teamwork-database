using System.Data.Entity;

namespace TeamVesper.Repositories.Contracts
{
    public interface ISqlServerDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();
    }
}
