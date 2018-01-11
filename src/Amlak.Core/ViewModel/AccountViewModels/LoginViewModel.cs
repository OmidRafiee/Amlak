using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Amlak.Core.ViewModel.AccountViewModels
{
    public class LoginViewModel
    {
        //[Required(ErrorMessage = "پست الکترونیکی خود را وارد نمائید")]
        //[EmailAddress(ErrorMessage = "پست الکترونیکی وارد شده نامعتبر است")]
        //[Display(Name = "پست الکترونیکی")]

        [Display(Name = "شماره موبایل")]
        [RegularExpression(@"^0?9[0123]\d{8}$", ErrorMessage = "شماره موبایل را بدرستی وارد نمائید")]
        [Required(ErrorMessage = "شماره موبایل خود را وارد نمائید")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "کلمه عبور را وارد نمائید")]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار؟")]
        public bool RememberMe { get; set; }


        [Display(Name = "حاصل جمع")]
        [Required(ErrorMessage = "لطفا حاصل جمع را وارد نمائید")]
        public string Captcha { get; set; }
    }
}
