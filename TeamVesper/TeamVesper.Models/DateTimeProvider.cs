using System;
using TeamVesper.Models.Contracts;

namespace TeamVesper.Models
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Current
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
