using System.ComponentModel.DataAnnotations;

public class ContactViewModel
{
    [Display(Name = "Your Name*")]
    [Required(ErrorMessage = "You must enter your name...")]
    public string Name { get; set; } = null!;

    [Display(Name = "Your Email*")]
    [Required(ErrorMessage = "You must enter your email address...")]
    [EmailAddress(ErrorMessage = "You must enter a valid email address...")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "You must enter a valid E-mail address")]
    public string Email { get; set; } = null!;

    [Display(Name = "Phone Number (optional)")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Company (optional)")]
    public string? CompanyName { get; set; }

    [Display(Name = "Message*")]
    [Required(ErrorMessage = "You must enter a message...")]
    public string CommentText { get; set; } = null!;

    [Display(Name = "Remember Me")]
    public bool RememberMe { get; set; }

}

