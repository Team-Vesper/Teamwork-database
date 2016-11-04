using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace TeamVesper.Repositories.Contracts
{
    public interface IDbContext
    {
        int SaveChanges();
    }
}
