using System.ComponentModel.DataAnnotations;

namespace blet15.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email daxil edin")]
        [EmailAddress(ErrorMessage = "Dogru email formati daxil edin")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Sifre daxil edin")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
