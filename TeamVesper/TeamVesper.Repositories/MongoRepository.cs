using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TeamVesper.Repositories.Contracts;

namespace TeamVesper.Repositories
{
    public class MongoRepository<TEntity> : IReadableRepository<TEntity>
    {
        private IMongoCollection<TEntity> dbSet;

        public MongoRepository(IMongoCollection<TEntity> dbSet)
        {
            this.DbSet = dbSet;
        }

        // finally found where to use prop with setter only! :D 
        protected IMongoCollection<TEntity> DbSet
        {
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Mongo DbSet");
                }

                this.dbSet = value;
            }
        }

        // TODO get decision repository get control from user !
        public IEnumerable<TEntity> All()
        {
            return this.All(_ => true);
        }

        public IEnumerable<TEntity> All(Expression<Func<TEntity, bool>> predicate)
        {
            // TODO get decision to list or not 
            // async generator
            return this.dbSet.Find(predicate).ToEnumerable();

            // whole collection
            // return this.dbSet.Find(predicate).ToList();
        }
    }
}
