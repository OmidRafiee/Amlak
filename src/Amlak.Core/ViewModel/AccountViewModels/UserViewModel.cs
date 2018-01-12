using System.ComponentModel.DataAnnotations;

namespace Amlak.Core.ViewModel.AccountViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "پست الکترونیکی خود را وارد نمائید")]
        [EmailAddress(ErrorMessage = "پست الکترونیکی وارد شده نامعتبر است")]
        [Display(Name = "پست الکترونیکی")]
        public string Email { get; set; }

        [Required(ErrorMessage = " نام مستعار را وارد نمائید", AllowEmptyStrings = false)]
        [Display(Name = " نام مستعار")]
        [StringLength(40, ErrorMessage = "تعداد کاراکتر ها می بایست حداکثر 40 کاراکتر باشد")]
        [RegularExpression(@"^[\u0600-\u06FF,\u0590-\u05FF\s]*$",
            ErrorMessage = "لطفا تنها از حروف فارسی استفاده نمائید")]
        public string PropFriendlyName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "کلمه عبور خود را وارد نمائید")]
        [StringLength(100, ErrorMessage = "کلمه عبور باید حداقل 6 حرف باشد", MinimumLength = 6)]
        [Display(Name = "کلمه عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "تعداد سکه را وارد نمائید")]
        [Display(Name = "تعداد سکه")]
        public int Coins { get; set; }
    }
}
