using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.ORM.Entities
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(length: 100, ErrorMessage = "Title length more then 20 symbols")]
        public string Title { get; set; }

        [MaxLength(length: 1000, ErrorMessage = "Description length more then 20 symbols")]
        public string Description { get; set; }

        public int? ManagerId { get; set; }

        [Required]
        public virtual Profile Manager { get; set; }

        public int? EmployeeId { get; set; }

        [Required]
        public virtual Profile Employee { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime DeadLine { get; set; }

        [Required]
        public TaskState State { get; set; }

        public int ProfileId { get; set; }

        public Profile Profile { get; set; }
    }
}
