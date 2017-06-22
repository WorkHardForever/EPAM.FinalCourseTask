using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.AspNetMvc.PL.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [Display(Name = nameof(Login))]
        public string Login { get; set; }

        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password don't match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [MaxLength(length: 20, ErrorMessage = "Name length more then {0} symbols")]
        [Display(Name = nameof(Name))]
        public string Name { get; set; }

        [Required]
        [MaxLength(length: 30, ErrorMessage = "Surname length more then {0} symbols")]
        [Display(Name = nameof(Surname))]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = nameof(Email))]
        public string Email { get; set; }
    }
}
