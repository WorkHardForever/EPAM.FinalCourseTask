using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.AspNetMvc.PL.Models.AdminViewModels
{
    public class AddRoleViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}