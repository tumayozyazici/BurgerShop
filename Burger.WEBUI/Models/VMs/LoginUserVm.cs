using Burger.DATA.Concrete;
using System.ComponentModel.DataAnnotations;

namespace Burger.WEBUI.Models.VMs
{
    public class LoginUserVm
    {
        [Display(Name = "Emailiniz:")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifreniz boş geçilemez.")]
        [Display(Name = "Şifre:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
