using System;
using TeamVesper.Repositories.Contracts;

namespace TeamVesper.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IDbContext context;

        public UnitOfWork(IDbContext context)
        {
            this.Context = context;
        }

        private IDbContext Context
        {
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("IContext");
                }

                this.context = value;
            }
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}
