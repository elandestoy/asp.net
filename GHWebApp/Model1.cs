using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace GHWebApp
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=ApplicationDbContext")
        {
        }

        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tdepts> tdepts { get; set; }
        public virtual DbSet<temployees> temployees { get; set; }
        public virtual DbSet<texps> texps { get; set; }
        public virtual DbSet<tjobs> tjobs { get; set; }
        public virtual DbSet<tlangs> tlangs { get; set; }
        public virtual DbSet<tlevel> tlevel { get; set; }
        public virtual DbSet<trisks> trisks { get; set; }
        public virtual DbSet<tskills> tskills { get; set; }
        public virtual DbSet<ttrainings> ttrainings { get; set; }
        public virtual DbSet<ttype> ttype { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tdepts>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<tdepts>()
                .HasMany(e => e.temployees)
                .WithRequired(e => e.tdepts)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<temployees>()
                .Property(e => e.RealID)
               .IsUnicode(false);

            modelBuilder.Entity<temployees>()
                .Property(e => e.FName)
                .IsUnicode(false);

            modelBuilder.Entity<temployees>()
                .Property(e => e.LName)
                .IsUnicode(false);

            modelBuilder.Entity<temployees>()
                .Property(e => e.Salary)
                .HasPrecision(19, 4);

            modelBuilder.Entity<temployees>()
                .Property(e => e.Recommended)
                .IsUnicode(false);

            modelBuilder.Entity<texps>()
                .Property(e => e.JobName)
                .IsUnicode(false);

            modelBuilder.Entity<texps>()
                .Property(e => e.Place)
                .IsUnicode(false);

            modelBuilder.Entity<texps>()
                .Property(e => e.Salary)
                .HasPrecision(19, 4);

            modelBuilder.Entity<texps>()
                .HasMany(e => e.temployees)
                .WithRequired(e => e.texps)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tjobs>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<tjobs>()
                .Property(e => e.MinSalary)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tjobs>()
                .Property(e => e.MaxSalary)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tjobs>()
                .HasMany(e => e.temployees)
                .WithRequired(e => e.tjobs)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tlangs>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<tlangs>()
                .HasMany(e => e.temployees)
                .WithRequired(e => e.tlangs)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tlevel>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<tlevel>()
                .HasMany(e => e.ttrainings)
                .WithRequired(e => e.tlevel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<trisks>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<trisks>()
                .HasMany(e => e.tjobs)
                .WithRequired(e => e.trisks)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tskills>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<tskills>()
                .HasMany(e => e.temployees)
                .WithRequired(e => e.tskills)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ttrainings>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ttrainings>()
                .Property(e => e.Place)
                .IsUnicode(false);

            modelBuilder.Entity<ttrainings>()
                .HasMany(e => e.temployees)
                .WithRequired(e => e.ttrainings)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ttype>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ttype>()
                .HasMany(e => e.temployees)
                .WithRequired(e => e.ttype)
                .WillCascadeOnDelete(false);
        }

        public System.Data.Entity.DbSet<GHWebApp.Models.EmployeeViewModel> EmployeeViewModels { get; set; }
    }
}
