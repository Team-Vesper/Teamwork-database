﻿using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;

namespace TeamVesper.MySqlData
{
    public class MySqlContext : OpenAccessContext
    {
        private static readonly BackendConfiguration BackendConfig = GetBackEndConfig();
        private static readonly MetadataSource MetaDataConfig = new MySqlModelConfiguration();

        private static string connectionName = "TheStoreMySqlConnection";

        public MySqlContext(string connectionString)
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
    }
}
