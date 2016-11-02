using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TeamVesper.Models;
using TeamVesper.MySqlData;
using TeamVesper.Repositories.Contracts;

namespace TeamVesper.Repositories
{
    public class MySqlRepository<TEntity> : IRepository<TEntity>
        where TEntity : DeveloperBugsInfo
    {

        private MySqlContext dbContext;

        public MySqlRepository(MySqlContext dbContext)
        {
            this.DbContext = dbContext;
        }

        private MySqlContext DbContext
        {
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Sql DbContext");
                }

                this.dbContext = value;
            }
        }

        public void Add(TEntity entity)
        {
            this.dbContext.Add(entity);
            this.dbContext.SaveChanges();
        }

        public void AddMany(IEnumerable<TEntity> entities)
        {
            this.dbContext.Add(entities);
            this.dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> All()
        {
            return this.dbContext.GetAll<TEntity>();
            this.dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> All(Expression<Func<TEntity, bool>> predicate)
        {
            return this.dbContext.GetAll<TEntity>().Where(predicate);
            this.dbContext.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            this.dbContext.Delete(entity);
            this.dbContext.SaveChanges();
        }

        public void RemoveMany(IEnumerable<TEntity> entities)
        {
            this.dbContext.Delete(entities);
            this.dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            this.dbContext.AttachCopy(entity);
            this.dbContext.SaveChanges();            

        }

        public void UpdateMany(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                this.dbContext.AttachCopy(entities);
            }

            this.dbContext.SaveChanges();
        }
    }
}
