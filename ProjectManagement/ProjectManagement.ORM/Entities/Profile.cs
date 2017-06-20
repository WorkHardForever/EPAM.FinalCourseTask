using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagement.ORM.Entities
{
    public class Profile
    {
        [Key]
        [ForeignKey("User")]
        public string Id { get; set; }

        [Required]
        [MaxLength(length: 20, ErrorMessage = "Name length more then 20 symbols")]
        public string Name { get; set; }

        [Required]
        [MaxLength(length: 30, ErrorMessage = "Surname length more then 20 symbols")]
        public string Surname { get; set; }

        public virtual ICollection<Task> GivenTasks { get; set; }

        public virtual ICollection<Task> ReceivedTasks { get; set; }

        //[ForeignKey("User")]
        //public string UserId { get; set; }
        
        public User User { get; set; }

        //TODO
        //public Firm Firm { get; set; }
    }
}
