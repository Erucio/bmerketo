using System.ComponentModel.DataAnnotations;

namespace ASP_Assignment.Models.ViewModels
{
    public class UserRegisterViewModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You must enter your first name...")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You must enter your last name...")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Street Name")]
        [Required(ErrorMessage = "You must enter your Street name...")]
        public string StreetName { get; set; } = null!;

        [Display(Name = "Postal Code")]
        [Required(ErrorMessage = "You must enter your Postal code...")]
        public string PostalCode { get; set; } = null!;

        [Display(Name = "City")]
        [Required(ErrorMessage = "You must enter your city...")]
        public string City { get; set; } = null!;

        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Company Name")]
        public string? CompanyName { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "You must enter your E-mail address...")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "You must enter a valid E-mail address")]
        public string Email { get; set; } = null!;

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You must enter a password...")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d).{7,}$", ErrorMessage = "Your password has to contain at least 7 characters, one capital letter and a number...")]
        public string Password { get; set; } = null!;

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "You must confirm your password...")]
        public string ConfirmPassword { get; set; } = null!;

        [Display(Name = "Profile Image")]
        [DataType(DataType.Upload)]
        public IFormFile? ImageFile { get; set; }

        [Display(Name = "I have read and agreed to the terms and conditions")]
        [Required(ErrorMessage = "You must accept the terms and conditions to continue...")]
        public bool TermsAndConditions { get; set; } = false;

    }
}
