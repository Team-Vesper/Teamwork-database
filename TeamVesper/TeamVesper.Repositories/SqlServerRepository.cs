using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using TeamVesper.Repositories.Contracts;

namespace TeamVesper.Repositories
{
    public class SqlServerRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private IDbSet<TEntity> set;
        private ICurrentSqlServerDbContext dbContext;

        public SqlServerRepository(ICurrentSqlServerDbContext context)
        {
            this.DbContext = context;
            this.Set = context.Set<TEntity>();
        }

        protected IDbSet<TEntity> Set
        {
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("SqlServer dbSet");
                }

                this.set = value;
            }
        }

        protected ICurrentSqlServerDbContext DbContext
        {
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("SqlServer dbContext");
                }

                this.dbContext = value;
            }
        }

        public void Add(TEntity entity)
        {
            var entry = this.AttachIfDetached(entity);
            entry.State = EntityState.Added;
        }

        public void AddMany(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                var entry = this.AttachIfDetached(entity);
                entry.State = EntityState.Added;
            }
        }

        public IEnumerable<TEntity> All()
        {
            return this.set.ToList();
        }

        public IEnumerable<TEntity> All(Expression<Func<TEntity, bool>> predicate)
        {
            var func = predicate.Compile();
            return this.All().Where(func).ToList();
        }

        public void Remove(TEntity entity)
        {
            var entry = this.AttachIfDetached(entity);
            entry.State = EntityState.Deleted;
        }

        public void RemoveMany(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                var entry = this.AttachIfDetached(entity);
                entry.State = EntityState.Added;
            }
        }

        //public void Update(TEntity entity)
        //{
        //    var entry = this.AttachIfDetached(entity);
        //    entry.State = EntityState.Modified;

        //}

        //public void UpdateMany(IEnumerable<TEntity> entities)
        //{
        //    foreach (var entity in entities)
        //    {
        //        var entry = this.AttachIfDetached(entity);
        //        entry.State = EntityState.Modified;
        //    }
        //}

        private DbEntityEntry<TEntity> AttachIfDetached(TEntity entity)
        {
            var entry = this.dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            return entry;
        }
    }
}
