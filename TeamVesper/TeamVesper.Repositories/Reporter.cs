using System;
using System.Collections.Generic;
using TeamVesper.Repositories.Contracts;

namespace TeamVesper.Repositories
{
    /// <summary>
    /// ! Important. Will be deleted do not inherit it !
    /// </summary>
    /// <typeparam name="TEntity">Model</typeparam>
    public abstract class Reporter<T> : IReporter<T>
    {
        // TODO Delete
        public abstract void ReportMany(IEnumerable<T> entities);

        public abstract void ReportSingle(T entity);
    }
}
