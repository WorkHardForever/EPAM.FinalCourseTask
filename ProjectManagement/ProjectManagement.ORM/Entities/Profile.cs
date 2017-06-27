using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagement.ORM.Entities
{
    public class Profile
    {
        public Profile()
        {
            GivenTasks = new HashSet<Task>();
            ReceivedTasks = new HashSet<Task>();
        }

        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }

        [Required]
        [MaxLength(length: 20, ErrorMessage = "Name length more then {0} symbols")]
        public string Name { get; set; }

        [Required]
        [MaxLength(length: 30, ErrorMessage = "Surname length more then {0} symbols")]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        //public virtual Avatar Avatar { get; set; }

        //public int FirmId { get; set; }

        //[ForeignKey("Firm")]
        //public virtual Firm Firm { get; set; }

        [InverseProperty("Manager")]
        public virtual ICollection<Task> GivenTasks { get; set; }

        [InverseProperty("Employee")]
        public virtual ICollection<Task> ReceivedTasks { get; set; }

        //public ICollection<Project> Projects { get; set; }

        public virtual User User { get; set; }
    }
}