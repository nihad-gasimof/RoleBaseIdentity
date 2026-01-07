using System.ComponentModel.DataAnnotations;

namespace blet15.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Istifadəçi adı tələb olunur")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email daxil edin")]
        [EmailAddress(ErrorMessage = "Doğru email formati daxil edin")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifrə daxil edin")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Şifrə ən az 6 simvol olmalıdır")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Təsdiq şifrə tələb olunur")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifrələr uyğun gəlmir")]
        public string ConfirmPassword { get; set; }
    }
}
