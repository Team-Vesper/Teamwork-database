using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TeamVesper.Models;
using TeamVesper.Repositories.Contracts;
using Telerik.OpenAccess;

namespace TeamVesper.Repositories
{
    // TODO Return control of save changes when fix unit of work !  

    public class MySqlRepository : IRepository<DeveloperBugsInfo>
    {

        private OpenAccessContext dbContext;

        public MySqlRepository(OpenAccessContext dbContext)
        {
            this.DbContext = dbContext;
        }

        private OpenAccessContext DbContext
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

        public void Add(DeveloperBugsInfo entity)
        {
            this.dbContext.Add(entity);

            this.dbContext.SaveChanges();
        }

        public void AddMany(IEnumerable<DeveloperBugsInfo> entities)
        {
            foreach (var entity in entities)
            {
                this.dbContext.Add(entity);
            }

            this.dbContext.SaveChanges();
        }

        public IEnumerable<DeveloperBugsInfo> All()
        {
            return this.dbContext.GetAll<DeveloperBugsInfo>().ToList();
        }

        public IEnumerable<DeveloperBugsInfo> All(Expression<Func<DeveloperBugsInfo, bool>> predicate)
        {
            var func = predicate.Compile();
            return this.All().Where(func).ToList();
        }

        public void Remove(DeveloperBugsInfo entity)
        {
            this.dbContext.Delete(entity);

            this.dbContext.SaveChanges();
        }

        public void RemoveMany(IEnumerable<DeveloperBugsInfo> entities)
        {
            foreach (var entity in entities)
            {
                this.dbContext.Delete(entity);
            }

            this.dbContext.SaveChanges();
        }

        //public void Update(TEntity entity)
        //{
        //    this.dbContext.AttachCopy(entity);

        //}

        //public void UpdateMany(IEnumerable<TEntity> entities)
        //{
        //    foreach (var entity in entities)
        //    {
        //        this.dbContext.Delete(entity);
        //    }
        //}
    }
}
