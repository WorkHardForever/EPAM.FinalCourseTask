using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.ORM.Entities
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        public string Telephone { get; set; }

        public virtual ICollection<Task> GivenTasks { get; set; }

        public virtual ICollection<Task> ReceivedTasks { get; set; }
    }
}
