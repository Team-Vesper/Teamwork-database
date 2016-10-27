using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using TeamVesper.Models;
using TeamVesper.SqlServerData.Contracts;

namespace TeamVesper.SqlServerData
{
    public class SqlServerDbContext : DbContext, ISqlServerDbContext
    {
        public SqlServerDbContext()
            : base("TeamVesperSqlServer")
        {
        }

        public virtual IDbSet<Developer> Developers { get; set; }

        public virtual IDbSet<Bug> Bugs { get; set; }

        public virtual IDbSet<Team> Teams { get; set; }

        public virtual IDbSet<Speciality> Specialities { get; set; }

        public virtual IDbSet<Priority> Priorities { get; set; }

        public new IDbSet<TEntity> Set<TEntity>()
            where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Developer>()
                .Property(x => x.UserName)
                .HasColumnAnnotation(
                        IndexAnnotation.AnnotationName,
                        new IndexAnnotation(
                                new IndexAttribute("IX_UserName", 1)
                                    {
                                        IsUnique = true
                                    }));

            base.OnModelCreating(modelBuilder);
        }
    }
}
