using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.ORM.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string PasswordHash { get; set; }

        public virtual Profile Profile { get; set; }

        public int RoleId { get; set; }

        [Required]
        public virtual Role Role { get; set; }
    }
}
