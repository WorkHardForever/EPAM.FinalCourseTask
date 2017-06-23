using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.AspNetMvc.PL.Models.AdminViewModels
{
    public class NewRoleViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
