using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.ORM.Entities
{
    public class Task
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(length: 100, ErrorMessage = "Title length more then 20 symbols")]
        public string Title { get; set; }

        [MaxLength(length: 1000, ErrorMessage = "Description length more then 20 symbols")]
        public string Description { get; set; }

        [Required]
        public Profile Manager { get; set; }

        [Required]
        public Profile Employee { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime DeadLine { get; set; }

        [Required]
        public TaskState State { get; set; }
    }
}