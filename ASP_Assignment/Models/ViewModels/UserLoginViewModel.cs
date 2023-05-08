using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ASP_Assignment.Models.ViewModels
{
    public class UserLoginViewModel
    {
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "You must enter your E-mail address...")]
        public string Email { get; set; } = null!;

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You must enter your password...")]
        public string Password { get; set; } = null!;

        [Display(Name = "Keep me logged in")]
        public bool RememberMe { get; set; } = false;

        public string ReturnUrl { get; set; } = "/";
    }
}
