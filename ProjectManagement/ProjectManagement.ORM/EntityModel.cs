using ProjectManagement.ORM.Entities;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ProjectManagement.ORM
{
    public partial class EntityModel : DbContext
    {
        public EntityModel()
            : base("EntityModel")
        { }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Role>()
            //    .HasMany(e => e.Users)
            //    .WithRequired(e => e.Role)
            //    .WillCascadeOnDelete(false);
        }
    }
}
