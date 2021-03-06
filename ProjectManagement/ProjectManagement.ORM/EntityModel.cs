﻿using ProjectManagement.ORM.Entities;
using System.Data.Entity;

namespace ProjectManagement.ORM
{
    public partial class EntityModel : DbContext
    {
        public EntityModel()
            : this("EntityModel")
        {
        }

        public EntityModel(string conectionString)
            : base(conectionString)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(p => p.Roles)
                .WithMany(c => c.Users);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.GivenTasks)
                .WithRequired(e => e.Manager)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.ReceivedTasks)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
