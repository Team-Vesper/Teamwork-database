using System.Collections.Generic;

namespace TeamVesper.Repositories.Contracts
{
    public interface IReporter<TEntity>
    {
        void ReportSingle(TEntity entity);

        void ReportMany(IEnumerable<TEntity> entities);
    }
}
