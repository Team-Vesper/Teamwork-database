
namespace TeamVesper.DbCreate.Contracts
{
    public interface IDbInitializerFactory
    {
        IDbInitializer GetMongoDbInitializer();

        IDbInitializer GetSqlServerInitializer();

        IDbInitializer GetSQLiteInitializer();
    }
}
