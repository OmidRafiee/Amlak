using System.ComponentModel.DataAnnotations;

namespace Amlak.Core.ViewModel.AccountViewModels
{
    public class ResetPasswordViewModel
    {
        [Display(Name = "شماره موبایل")]
        [RegularExpression(@"^0?9[0123]\d{8}$", ErrorMessage = "شماره موبایل را بدرستی وارد نمائید")]
        [Required(ErrorMessage = "شماره موبایل خود را وارد نمائید")]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "کلمه عبور خود را وارد نمائید")]
        [StringLength(100, ErrorMessage = "کلمه عبور باید حداقل 6 حرف باشد", MinimumLength = 6)]
        [Display(Name = "کلمه عبور جدید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "تکرار کلمه عبور خود را وارد نمائید")]
        [Display(Name = "تکرار کلمه عبور جدید")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "تکرار کلمه عبور، با کلمه عبور یکسان نیست")]
        public string ConfirmPassword { get; set; }

        //[Display(Name = "حاصل جمع")]
        //[Required(ErrorMessage = "لطفا حاصل جمع را وارد نمائید")]
        //public string Captcha { get; set; }

        [Required(ErrorMessage = "کد فعال سازی را وارد نمایید")]
        [Display(Name = "کد فعال سازی")]
        public string Code { get; set; }
    }
}
