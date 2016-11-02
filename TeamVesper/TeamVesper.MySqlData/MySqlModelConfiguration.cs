using System.Collections.Generic;
using System.Linq;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Metadata.Fluent;

namespace TeamVesper.MySqlData
{
    public class MySqlModelConfiguration : FluentMetadataSource
    {
        protected override IList<MappingConfiguration> PrepareMapping()
        {
            List<MappingConfiguration> configurations = new List<MappingConfiguration>();

            //var salesMapping = new MappingConfiguration<SalesReport>();
            //salesMapping.HasProperty(c => c.Id).IsIdentity(KeyGenerator.Autoinc);

            //salesMapping.MapType(report => new
            //{
            //    // Id = report.Id,
            //    Town = report.Town,
            //    Date = report.Date,                             <= TODO watch this!
            //    LaptopId = report.LaptopId,
            //    Quantity = report.Quantity,
            //    Sum = report.Sum
            //}).ToTable("sales");

            // configurations.Add(salesMapping);

            return configurations;
        }
    }
}
