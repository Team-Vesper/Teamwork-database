using Ninject.Modules;
using TeamVesper.UI.Contracts;
using Ninject.Extensions.Factory;
using TeamVesper.DbCreate.Contracts;
using TeamVesper.DbCreate;
using TeamVesper.SqlServerData;
using TeamVesper.MongoDbData;
using TeamVesper.Models;
using TeamVesper.Repositories.Contracts;
using Ninject;
using Ninject.Parameters;
using TeamVesper.Repositories;
using TeamVesper.SQLiteData;
using TeamVesper.Importers;
using TeamVesper.XmlDataReader;
using TeamVesper.ExportToJson;
using TeamVesper.ExportToExcel;
using TeamVesper.ExportToPdf;
using TeamVesper.ExportToXML;
using Telerik.OpenAccess;
using TeamVesper.MySqlData;
using TeamVesper.ExportToJson.Contracts;
using TeamVesper.Mappers;

namespace TeamVesper.UI.Modules
{
    public class TeamVesperModule : NinjectModule
    {
        private const string DefaultReportPath = @"../../../reports/";
        private const string DefaultFileName = "Report";
        private const string DefaultSheetName = "Company";

        private const string CreateDbForm = "CreateDbForm";
        private const string ImportForm = "ImportForm";
        private const string TransferForm = "TransferForm";
        private const string ExportForm = "ExportForm";

        private const string MongoDbInitializer = "MongoDbInitializer";
        private const string SqlServerInitializer = "SqlServerInitializer";
        private const string SQLiteInitializer = "SQLiteInitializer";

        private const string MongoDeveloperReadableRepository = "MongoDeveloperReadableRepository";
        private const string SQLiteReadableRepository = "SQLiteReadableRepository";
        private const string XmlReadableRepository = "XmlReadableRepository";
        private const string ExcelReadableRepository = "ExcelReadableRepository";

        private const string SqlServerRepository = "SqlServerRepository";
        private const string MySqlRepository = "MySqlRepository";

        private const string JsonReporter = "JsonReporter";
        private const string XmlReporter = "XmlReporter";
        private const string PdfReporter = "PdfReporter";
        private const string ExcelReporter = "ExcelReporter";

        private const string SqlServerUnitOFWork = "SqlServerUnitOFWork";
        private const string MySqlUnitOfWork = "MySqlUnitOfWork";

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

            Bind<IRepositoryFactory>().ToFactory().InSingletonScope();

            Bind<IReadableRepository<Company>>().To<SQLiteImport>().InSingletonScope().Named(SQLiteReadableRepository);
            Bind<IReadableRepository<Bug>>().To<ExcelImporter>().InSingletonScope().Named(ExcelReadableRepository);
            Bind<IReadableRepository<DTOEducation>>().To<XmlImporter>().InSingletonScope().Named(XmlReadableRepository);
            Bind<IReadableRepository<MongoDeveloper>>().ToMethod(ctx =>
            {
                var connector = ctx.Kernel.Get<MongoConnector<MongoDeveloper>>();
                var param = new ConstructorArgument("dbSet", connector.Dbset);

                var repo = ctx.Kernel.Get<MongoRepository<MongoDeveloper>>(param);

                return repo;

            }).InSingletonScope().Named(MongoDeveloperReadableRepository);

            Bind(typeof(IRepository<>)).To(typeof(SqlServerRepository<>)).Named(SqlServerRepository);
            Bind<IRepository<DeveloperBugsInfo>>().To<MySqlRepository<DeveloperBugsInfo>>().Named(MySqlRepository);

            Bind<IReporterFactory>().ToFactory().InSingletonScope();

            Bind<IReporter<MongoDeveloper>>().ToMethod(ctx =>
            {
                var param = new ConstructorArgument("folderPath", DefaultReportPath + @"Json/");

                return ctx.Kernel.Get<JsonToFile>(param);
            }).Named(JsonReporter);

            Bind<IReporter<CompanyOverview>>().ToMethod(ctx =>
            {
                var paramSheetName = new ConstructorArgument("sheetName", DefaultSheetName);
                var paramFolder = new ConstructorArgument("outputFolder", DefaultReportPath + @"Excel/");
                var paramFile = new ConstructorArgument("outputFileName", DefaultFileName);

                return ctx.Kernel.Get<CompanyExcelExporter>(paramSheetName, paramFolder, paramFile);
            }).Named(ExcelReporter);

            Bind<IReporter<BugInfo>>().ToMethod(ctx =>
            {
                var param = new ConstructorArgument("folderPath", DefaultReportPath + @"Pdf/");

                return ctx.Kernel.Get<PdfExporter>(param);
            }).Named(PdfReporter);

            Bind<IReporter<BugReport>>().ToMethod(ctx =>
            {
                var param = new ConstructorArgument("folderPath", DefaultReportPath + @"Xml/");

                return ctx.Kernel.Get<BugReportToXml>(param);
            }).Named(XmlReporter);

            Bind<IUnitOfWorkFactory>().ToFactory().InSingletonScope();

            // coz Telerik.OpenAccess.IUnitOfWork exsist
            Bind<Repositories.Contracts.IUnitOfWork>().ToMethod(ctx =>
            {
                var dbContext = ctx.Kernel.Get<SqlServerDbContext>();

                var param = new ConstructorArgument("context", dbContext);

                return ctx.Kernel.Get<UnitOfWork>(param);
            }).Named(SqlServerUnitOFWork);

            Bind<Repositories.Contracts.IUnitOfWork>().ToMethod(ctx =>
            {
                var dbContext = ctx.Kernel.Get<MySqlContext>();

                var param = new ConstructorArgument("context", dbContext);

                return ctx.Kernel.Get<UnitOfWork>(param);
            }).Named(MySqlUnitOfWork);

            // TODO Dependencies bindings

            Bind<SqlServerDbContext>().To<SqlServerDbContext>().InSingletonScope();
            Bind<MongoConnector<MongoDeveloper>>().To<MongoConnector<MongoDeveloper>>().InSingletonScope();
            Bind<ICurrentSqlServerDbContext>().To<SqlServerDbContext>();
            Bind<OpenAccessContext>().To<MySqlContext>().InSingletonScope();
            Bind<MySqlContext>().To<MySqlContext>().InSingletonScope();
            Bind<IJsonSeriliazer>().To<JsonSeriliazer>();
            Bind<StarndartModelsToMongoModelMapper>().To<StarndartModelsToMongoModelMapper>();
        }
    }
}
