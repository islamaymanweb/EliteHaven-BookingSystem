namespace   EliteHaven.Web.ViewModels;


public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Password and Confirm Password does not match")]
    [Display(Name = "Confirm Password")]
    public string? ConfirmPassword { get; set; }
    [Required(ErrorMessage = "Your name is important for us...")]
    public string? Name { get; set; }
    [Display(Name = "Phone Number")]
    public string? PhoneNumber { get; set; }
    public string? RedirectUrl { get; set; }

    public string? Role { get; set; }

    [ValidateNever]
    public IEnumerable<SelectListItem>? RoleList { get; set; }
}
