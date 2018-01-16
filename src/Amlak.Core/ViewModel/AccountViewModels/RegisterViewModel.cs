using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Amlak.Core.ViewModel.AccountViewModels
{
    public class RegisterViewModel
    {
        //[Required(ErrorMessage = "پست الکترونیکی خود را وارد نمائید")]
        [EmailAddress(ErrorMessage = "پست الکترونیکی وارد شده نامعتبر است")]
        [Display(Name = "پست الکترونیکی")]
       // [Remote("ValidateEmail", "Api", HttpMethod = "POST",ErrorMessage = " ایمیل وارد شده هم اکنون توسط یکی از کاربران مورد استفاده است")]
        public string Email { get; set; }

        [Required(ErrorMessage = "شماره موبایل خود را وارد نمائید")]
        [Display(Name = " شماره موبایل (شناسه کاربری)")]
        [RegularExpression(@"^[\u0000-\u007F\s]*$",ErrorMessage = "لطفا تنها از حروف لاتین استفاده نمائید")]
       // [Remote("ValidatePhoneNumber", "Api", HttpMethod = "POST")]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "کلمه عبور خود را وارد نمائید")]
        [StringLength(100, ErrorMessage = "کلمه عبور باید حداقل 6 حرف باشد", MinimumLength = 6)]
        [Display(Name = "کلمه عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "تکرار کلمه عبور خود را وارد نمائید")]
        [Display(Name = "تکرار کلمه عبور")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "تکرار کلمه عبور، با کلمه عبور یکسان نیست")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = " نام مستعار را وارد نمائید", AllowEmptyStrings = false)]
        [Display(Name = " نام مستعار")]
        [StringLength(40, ErrorMessage = "تعداد کاراکتر ها می بایست حداکثر 40 کاراکتر باشد")]
        [RegularExpression(@"^[\u0600-\u06FF,\u0590-\u05FF\s]*$",
            ErrorMessage = "لطفا تنها از حروف فارسی استفاده نمائید")]
      //  [Remote("ValidateFriendlyName", "Api", HttpMethod = "POST", ErrorMessage = " نام مستعار وارد شده هم اکنون توسط یکی از کاربران مورد استفاده است")]
        public string FriendlyName { get; set; }

        //[Display(Name = "حاصل جمع")]
        //[Required(ErrorMessage = "لطفا حاصل جمع را وارد نمائید")]
        //public string Captcha { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
}
