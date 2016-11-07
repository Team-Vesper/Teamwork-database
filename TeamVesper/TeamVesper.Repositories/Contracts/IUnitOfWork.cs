using System;

namespace TeamVesper.Repositories.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
