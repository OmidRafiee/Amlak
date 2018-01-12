using System.ComponentModel.DataAnnotations;

namespace Amlak.Core.ViewModel.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Display(Name = "شماره موبایل")]
        [RegularExpression(@"^0?9[0123]\d{8}$", ErrorMessage = "شماره موبایل را بدرستی وارد نمائید")]
        [Required(ErrorMessage = "شماره موبایل خود را وارد نمائید")]
        public string PhoneNumber { get; set; }

        //[Display(Name = "حاصل جمع")]
        //[Required(ErrorMessage = "لطفا حاصل جمع را وارد نمائید")]
        //public string Captcha { get; set; }

    }
}
