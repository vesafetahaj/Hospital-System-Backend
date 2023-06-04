using System.ComponentModel.DataAnnotations;

namespace Hospital_System_Management.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDoctor { get; set; }
        public bool IsPatient { get; set; }
        public bool IsReceptionist { get; set; }
    }
}
