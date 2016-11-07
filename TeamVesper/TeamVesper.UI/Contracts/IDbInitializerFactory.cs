using TeamVesper.DbCreate.Contracts;

namespace TeamVesper.UI.Contracts
{
    public interface IDbInitializerFactory
    {
        IDbInitializer GetMongoDbInitializer();

        IDbInitializer GetSqlServerInitializer();

        IDbInitializer GetSQLiteInitializer();

        IDbInitializer GetMySqlInitializer();
    }
}
