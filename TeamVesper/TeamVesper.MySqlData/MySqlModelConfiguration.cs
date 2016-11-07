using System.Collections.Generic;
using TeamVesper.Models;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Metadata.Fluent;

namespace TeamVesper.MySqlData
{
    public class MySqlModelConfiguration : FluentMetadataSource
    {
        protected override IList<MappingConfiguration> PrepareMapping()
        {
            List<MappingConfiguration> configurations = new List<MappingConfiguration>();

            var DevBugMap = new MappingConfiguration<DeveloperBugsInfo>();

            DevBugMap.HasProperty(x => x.Id).IsIdentity(KeyGenerator.Autoinc);

            DevBugMap.MapType(x => new
            {
                Username = x.UserName,
                FirstName = x.FirstName,
                LastName = x.LastName,
                BugsFixed = x.BugsFixed
            }).ToTable("DeveloperBugsInfo");

            configurations.Add(DevBugMap);

            return configurations;
        }
    }
}
