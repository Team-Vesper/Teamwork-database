using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TeamVesper.Repositories.Contracts;

namespace TeamVesper.Repositories
{
    public class SqlServerRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private IDbSet<TEntity> dbSet;
        private ISqlServerDbContext dbContext;

        public SqlServerRepository(ISqlServerDbContext context)
        {
            this.DbContext = context;
            this.DbSet = context.Set<TEntity>();
        }

        protected IDbSet<TEntity> DbSet
        {
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("SqlServer dbSet");
                }

                this.dbSet = value;
            }
        }

        protected ISqlServerDbContext DbContext
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
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }

        public void AddMany(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                this.dbSet.Add(entity);
            }

            this.dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> All()
        {
            // TODO get decision to list or not 
            return this.dbSet;
        }

        public IEnumerable<TEntity> All(Expression<Func<TEntity, bool>> predicate)
        {
            // TODO get decision to list or not 
            return this.dbSet.Where(predicate);
        }

        public void Remove(TEntity entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }

        public void RemoveMany(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                this.dbSet.Remove(entity);
            }

            this.dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            var dbEntry = this.dbContext.Entry(entity);
            dbEntry.State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }

        public void UpdateMany(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                var dbEntry = this.dbContext.Entry(entity);
                dbEntry.State = EntityState.Modified;
            }

            this.dbContext.SaveChanges();
        }
    }
}
