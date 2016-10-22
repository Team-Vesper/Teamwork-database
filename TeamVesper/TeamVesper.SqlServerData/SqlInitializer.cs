using System;

using TeamVesper.Models.Contracts;

namespace TeamVesper.SqlServerData
{
    public class SqlInitializer
    {
        public SqlInitializer(IDateTimeProvider provider)
        {
            this.InitialDate = provider.Current;
        }

        public int Id { get; set; }

        public DateTime InitialDate { get; set; }
    }
}
