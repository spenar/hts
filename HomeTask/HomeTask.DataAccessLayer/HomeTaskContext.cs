using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using HomeTask.Models;

namespace HomeTask.Core
{
    public class HomeTaskContext : DbContext
    {

        public HomeTaskContext()
            : base("name=HomeTaskDB")
        {
        }
        public DbSet<Group> Groups { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<TypeOfTask> TypesOfTasks { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Group2Subject> Group2Subject { get; set; }

        public DbSet<Group2Teacher> Group2Teacher { get; set; }

        public DbSet<Institution2User> Institution2User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
