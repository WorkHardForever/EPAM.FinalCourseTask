using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.AspNetMvc.PL.Models.DashboardViewModels
{
    public class NewTaskViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string EmployeeEmail { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DeadLine { get; set; }
    }
}
