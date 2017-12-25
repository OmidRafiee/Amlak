using System.ComponentModel.DataAnnotations;

namespace Amlak.Core.ViewModel.House
{
    public class CreateHouseViewModel
    {

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "عنوان ملک را وارد نمایید",AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [StringLength(100, ErrorMessage = "کلمه عبور باید حداقل 6 حرف باشد", MinimumLength = 6)]

        public string Description { get; set; }

        /// <summary>
        /// وضیعت
        /// </summary>
        [Display(Name = "وضیعت")]
        [StringLength(100, ErrorMessage = "کلمه عبور باید حداقل 6 حرف باشد", MinimumLength = 6)]

        public string Status { get; set; }

        /// <summary>
        /// قیمت
        /// </summary>
        [Display(Name = "قیمت")]
        public long Price { get; set; }

        /// <summary>
        /// تعداد اتاق
        /// </summary>
        [Display(Name = "تعدا اتاق")]
        public int Rooms { get; set; }

        /// <summary>
        /// تعداد حمام
        /// </summary>
        [Display(Name = "تعداد حمام")]
        public int Bathrooms { get; set; }

        /// <summary>
        /// تعداد پارکینگ
        /// </summary>
        [Display(Name = "تعداد پارکینگ")]
        public int Parkings { get; set; }

        /// <summary>
        /// امکانات که برای مثال شامل
        ///سیستم گرمایشی ، کولر 
        /// </summary>
        [Display(Name = "امکانات")]
        public string PossibilitiesIdsJson { get; set; }

        /// <summary>
        /// مکان جغرافیای
        /// </summary>
        [Display(Name = "مکان جغرافیایی")]
        public string Loacation { get; set; }

        /// <summary>
        /// تصاویر ملک
        /// </summary>
        [Display(Name = "تصاویر ملک")]
        public string PhotoGalleryJson { get; set; }

        /// <summary>
        /// متراژ ملک
        /// </summary>
        [Display(Name = "متراژ")]
        public string Scale { get; set; }

        /// <summary>
        /// منطفه
        /// </summary>
        [Display(Name = "منطقه")]
        public string Region { get; set; }

        /// <summary>
        /// شهر
        /// </summary>
        [Display(Name = "شهر")]
        public string City { get; set; }

        /// <summary>
        /// استان
        /// </summary>
        [Display(Name = "استان")]
        public string Town { get; set; }


        /// <summary>
        /// محله
        /// </summary>
        [Display(Name = "محله")]

        public string Area { get; set; }

        /// <summary>
        /// طبقه 
        ///  </summary>
        [Display(Name = "طبقه")]
        public int Floor { get; set; }

        
        public int? UserId { get; set; }


        [Display(Name = "نوع ملک")]
        public int? CategoryId { get; set; }
    }
}
