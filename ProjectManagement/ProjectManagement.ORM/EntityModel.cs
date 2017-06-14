using Microsoft.AspNet.Identity.EntityFramework;
using ProjectManagement.ORM.Entities;
using System.Data.Entity;

namespace ProjectManagement.ORM
{
    public partial class EntityModel : IdentityDbContext<User>
    {
        public EntityModel()
            : base("EntityModel")
        { }

        public EntityModel(string conectionString)
            : base(conectionString)
        { }

        public virtual DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Role>()
            //    .HasMany(e => e.Users)
            //    .WithRequired(e => e.Role)
            //    .WillCascadeOnDelete(false);
        }
    }
}
