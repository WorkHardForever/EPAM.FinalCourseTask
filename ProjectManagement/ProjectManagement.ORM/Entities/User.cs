using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagement.ORM.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string Login { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public virtual Profile Profile { get; set; }
        
        public int RoleId { get; set; }
        
        public virtual Role Role { get; set; }
    }
}
