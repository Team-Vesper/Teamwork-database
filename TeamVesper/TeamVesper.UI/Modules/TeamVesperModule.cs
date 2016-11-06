using Ninject.Modules;
using TeamVesper.UI.Contracts;
using Ninject.Extensions.Factory;
using TeamVesper.DbCreate.Contracts;
using TeamVesper.DbCreate;
using TeamVesper.SqlServerData;

namespace TeamVesper.UI.Modules
{
    public class TeamVesperModule : NinjectModule
    {
        private const string CreateDbForm = "CreateDbForm";
        private const string ImportForm = "ImportForm";
        private const string TransferForm = "TransferForm";
        private const string ExportForm = "ExportForm";

        private const string MongoDbInitializer = "MongoDbInitializer";
        private const string SqlServerInitializer = "SqlServerInitializer";
        private const string SQLiteInitializer = "SQLiteInitializer";

        public override void Load()
        {
            Bind<MainForm>().To<MainForm>().InSingletonScope();

            Bind<IFormFactory>().ToFactory().InSingletonScope();
            Bind<CreateDBForm>().To<CreateDBForm>().Named(CreateDbForm);
            Bind<ImportForm>().To<ImportForm>().Named(ImportForm);
            Bind<TransferForm>().To<TransferForm>().Named(TransferForm);
            Bind<ExportForm>().To<ExportForm>().Named(ExportForm);

            Bind<IDbInitializerFactory>().ToFactory().InSingletonScope();
            Bind<IDbInitializer>().To<MongoDbInitializer>().Named(MongoDbInitializer);
            Bind<IDbInitializer>().To<SqlServerInitializer>().Named(SqlServerInitializer);
            Bind<IDbInitializer>().To<SQLiteInitializer>().Named(SQLiteInitializer);

            Bind<SqlServerDbContext>().To<SqlServerDbContext>().InSingletonScope();
        }
    }
}
