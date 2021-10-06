using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ltap.Models
{
    public class LapTrinhQuanLyDBcontext : DbContext
    {
        public LapTrinhQuanLyDBcontext() : base("LapTrinhQuanLyDBcontext")
        {
        }

        public virtual DbSet<AccountModel> Accounts { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Article> Articles { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .Property(e => e.RoleID)
                .IsUnicode(false);
            modelBuilder.Entity<Role>()
                .Property(e => e.RoleName)
                .IsUnicode(true);
        }
    }
}
//DESKTOP-GIPHEE4\SQLEXPRESS