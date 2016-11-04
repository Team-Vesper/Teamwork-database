using System;
using TeamVesper.Repositories.Contracts;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;

namespace TeamVesper.MySqlData
{
    public class MySqlContext : OpenAccessContext, IDbContext
    {
        private static readonly BackendConfiguration BackendConfig = GetBackEndConfig();
        private static readonly MetadataSource MetaDataConfig = new MySqlModelConfiguration();

        // private static string connectionName = "TeamVesperMySql";
        private const string defaultConnectionString = "server=localhost;database=TeamVesperMySql;uid=root;pwd=pass";

        public MySqlContext(string connectionString = defaultConnectionString)
            : base(connectionString, BackendConfig, MetaDataConfig)
        {
        }

        private static BackendConfiguration GetBackEndConfig()
        {
            var config = new BackendConfiguration();

            config.Backend = "MySql";
            config.ProviderName = "MySql.Data.MySqlClient";

            return config;
        }

        int IDbContext.SaveChanges()
        {
            this.SaveChanges();
            return 0;
        }
    }
}
