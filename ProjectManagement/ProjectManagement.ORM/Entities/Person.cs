using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagement.ORM.Entities
{
    public class Person
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public virtual ICollection<Task> GivenTasks { get; set; }

        public virtual ICollection<Task> ReceivedTasks { get; set; }
    }
}
