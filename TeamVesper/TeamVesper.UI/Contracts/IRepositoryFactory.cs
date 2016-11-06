using TeamVesper.Repositories.Contracts;

namespace TeamVesper.UI.Contracts
{
    public interface IRepositoryFactory
    {
        IReadableRepository<TEntity> GetMongoDeveloperReadableRepository<TEntity>();

        IReadableRepository<TEntity> GetSQLiteReadableRepository<TEntity>();

        IReadableRepository<TEntity> GetXmlReadableRepository<TEntity>();

        IReadableRepository<TEntity> GetExcelReadableRepository<TEntity>();

        IRepository<TEntity> GetSqlServerRepository<TEntity>();

        IRepository<TEntity> GetMySqlRepository<TEntity>();
    }
}
