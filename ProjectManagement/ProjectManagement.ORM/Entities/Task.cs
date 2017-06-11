using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.ORM.Entities
{
    public enum TaskState
    {
        ToDo,
        InProcess,
        Done
    }

    public class Task
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        public string Description { get; set; }

        [Required]
        public Person Manager { get; set; }

        [Required]
        public Person Employee { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime DeadLine { get; set; }

        public TaskState State { get; set; }
    }
}