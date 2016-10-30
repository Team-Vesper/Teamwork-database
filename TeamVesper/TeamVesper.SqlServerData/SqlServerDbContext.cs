using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Annotations;
using TeamVesper.Models;
using TeamVesper.Repositories.Contracts;
using TeamVesper.SqlServerData.Contracts;

namespace TeamVesper.SqlServerData
{
    public class SqlServerDbContext : DbContext, ICurrentSqlServerDbContext, ISqlServerDbContext
    {

        public SqlServerDbContext()
            :base ("TeamVesperSqlServer")
        {

        }

        //public SqlServerDbContext(string nameOfConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TeamVesperSqlServer;Integrated Security=True;MultipleActiveResultSets=True")
        //    : base()
        //{
        //}

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
                            new IndexAttribute("IX_Developer_UserName", 1)
                            {
                                IsUnique = true,
                                IsClustered = false
                            }));

            modelBuilder
                .Entity<Team>()
                .Property(x => x.Name)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                            new IndexAttribute("IX_Speciality_Name", 1)
                            {
                                IsUnique = true,
                                IsClustered = false
                            }));

            modelBuilder
                .Entity<Speciality>()
                .Property(x => x.Name)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                            new IndexAttribute("IX_Speciality_Name", 1)
                            {
                                IsUnique = true,
                                IsClustered = false
                            }));

            modelBuilder
                .Entity<Priority>()
                .Property(x => x.Name)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                            new IndexAttribute("IX_Peiority_Name", 1)
                            {
                                IsUnique = true,
                                IsClustered = false
                            }));

            base.OnModelCreating(modelBuilder);
        }
    }
}
