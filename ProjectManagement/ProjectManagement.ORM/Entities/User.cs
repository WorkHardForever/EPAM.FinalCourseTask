using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.ORM.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual Role Role { get; set; }
    }
}
