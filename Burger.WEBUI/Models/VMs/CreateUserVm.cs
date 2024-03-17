using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Burger.WEBUI.Models.VMs
{
    public class CreateUserVm
    {
        [Required(ErrorMessage = "Adınız boş geçilemez.")]
        [Display(Name ="Adınız:")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyadınız boş geçilemez.")]
        [Display(Name = "Soyadınız:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Emailiniz boş geçilemez.")]
        [Display(Name = "Emailiniz:")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifreniz boş geçilemez.")]
        [Display(Name = "Şifre:")]
        [DataType(DataType.Password)]
        [StringLength(12, MinimumLength = 5, ErrorMessage = "Şifre en az 5 en fazla 12 karakter olmalıdır!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifreniz boş geçilemez.")]
        [Compare("Password",ErrorMessage ="Şifre aynı olmak zorundadır.")]
        [Display(Name = "Şifre Tekrarı:")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Adresiniz boş geçilemez.")]
        [Display(Name = "Adress:")]
        public string Address { get; set; }
    }
}