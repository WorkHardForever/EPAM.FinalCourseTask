﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagement.ORM.Entities
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(length: 100, ErrorMessage = "Title length more then 20 symbols")]
        public string Title { get; set; }

        [Required]
        [MaxLength(length: 1000, ErrorMessage = "Description length more then 20 symbols")]
        public string Description { get; set; }

        [Required]
        public int ManagerId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [ForeignKey("ManagerId")]
        public virtual Profile Manager { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Profile Employee { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime DeadLine { get; set; }

        [Required]
        public TaskState State { get; set; }
    }
}
