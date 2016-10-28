using System;
using System.Collections.Generic;
using TeamVesper.Repositories.Contracts;

namespace TeamVesper.Repositories
{
    /// <summary>
    /// ! Important. Will be deleted do not inherit it !
    /// </summary>
    /// <typeparam name="TEntity">Model</typeparam>
    public abstract class ReadableRepository<TEntity> : IReadableRepository<TEntity>
    {
        // TODO Delete 
        public abstract IEnumerable<TEntity> All();

        public abstract TEntity FindById(object id);
    }
}
