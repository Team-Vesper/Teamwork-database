using System;
using System.Data.Entity;
using System.Linq;
using TeamVesper.SqlServerData.Contracts;

namespace TeamVesper.SqlServerData
{
    public class EfRepository<TEntiry> : IRepository<TEntiry>
        where TEntiry : class
    {
        private readonly ISqlServerDbContext dbContext;

        private readonly IDbSet<TEntiry> set;

        public EfRepository(ISqlServerDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.set = dbContext.Set<TEntiry>();
        }

        public IQueryable<TEntiry> All()
        {
            return this.set;
        }

        public void Add(TEntiry entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }


        public TEntiry FindById(object id)
        {
            return this.set.Find(id);
        }

        public void Update(TEntiry entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public void Remove(TEntiry entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        private void ChangeState(TEntiry entity, EntityState state)
        {
            var dbEntry = this.dbContext.Entry(entity);
            dbEntry.State = state;
        }
    }
}
