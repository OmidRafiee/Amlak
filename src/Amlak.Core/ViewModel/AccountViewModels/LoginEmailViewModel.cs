using System.ComponentModel.DataAnnotations;

namespace Amlak.Core.ViewModel.AccountViewModels
{
    public class LoginEmailViewModel
    {
        [Required(ErrorMessage = "پست الکترونیکی خود را وارد نمائید")]
        [EmailAddress(ErrorMessage = "پست الکترونیکی وارد شده نامعتبر است")]
        [Display(Name = "پست الکترونیکی")]
        public string Email { get; set; }

        [Required(ErrorMessage = "کلمه عبور را وارد نمائید")]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار؟")]
        public bool RememberMe { get; set; }

      
    }
}
