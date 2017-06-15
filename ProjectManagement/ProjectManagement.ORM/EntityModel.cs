using Microsoft.AspNet.Identity.EntityFramework;
using ProjectManagement.ORM.Entities;
using System.Data.Entity;

namespace ProjectManagement.ORM
{
    public partial class EntityModel : IdentityDbContext<User>
    {
        public EntityModel()
            : this("EntityModel")
        { }

        public EntityModel(string conectionString)
            : base(conectionString)
        { }

        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            modelBuilder.Entity<Person>()
                .HasMany(e => e.GivenTasks)
                .WithRequired(e => e.ManagerPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.ReceivedTasks)
                .WithRequired(e => e.EmployeePerson)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
