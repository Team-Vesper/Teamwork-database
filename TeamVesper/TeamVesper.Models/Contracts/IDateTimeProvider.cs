using System;

namespace TeamVesper.Models.Contracts
{
    public interface IDateTimeProvider
    {
        DateTime Current { get; }
    }
}
