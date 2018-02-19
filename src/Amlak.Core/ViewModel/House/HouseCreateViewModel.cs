using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Amlak.Core.ViewModel.House
{
    public class HouseCreateViewModel
    {

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "عنوان ملک را وارد نمایید", AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        /// <summary>
        /// وضیعت
        /// </summary>
        [Display(Name = "وضیعت")]
        public string Status { get; set; }

        /// <summary>
        /// قیمت
        /// </summary>
        [Display(Name = " قیمت (ريال)")]
        [Required(ErrorMessage = "قیمت را وارد کنید")]
        [Range(0, long.MaxValue, ErrorMessage = "مقدار وارد شده نامعتبر است")]

        public long Price { get; set; }


        /// <summary>
        /// رهن سالانه
        /// در صورت انتخاب وضیعت به رهن یا اجاره 
        /// این را پر میکینیم
        /// </summary>
        [Display(Name = " ودیعه (ريال)")]
        [Range(0, long.MaxValue, ErrorMessage = "مقدار وارد شده نامعتبر است")]
        public long? SalaryPrice { get; set; }

        /// <summary>
        /// اجاره ماهانه
        /// در صورت انتخاب وضیعت به رهن یا اجاره 
        /// این را پر میکینیم
        /// </summary>
        [Display(Name = " اجاره ماهانه (ريال)")]
        [Range(0, long.MaxValue, ErrorMessage = "مقدار وارد شده نامعتبر است")]
        public long? MonthPrice { get; set; }
        /// <summary>
        /// تعداد اتاق
        /// </summary>
        [Display(Name = "تعدا اتاق")]
        [Required(ErrorMessage = "تعداد اتاق را وارد کنید")]
        [Range(0, long.MaxValue, ErrorMessage = "مقدار وارد شده نامعتبر است")]
        public int Rooms { get; set; }

        /// <summary>
        /// تعداد حمام
        /// </summary>
        [Display(Name = "تعداد حمام")]
        [Range(0, long.MaxValue, ErrorMessage = "مقدار وارد شده نامعتبر است")]

        public int Bathrooms { get; set; }

        /// <summary>
        /// تعداد پارکینگ
        /// </summary>
        [Display(Name = "تعداد پارکینگ")]
        [Range(0, long.MaxValue, ErrorMessage = "مقدار وارد شده نامعتبر است")]

        public int Parkings { get; set; }

        /// <summary>
        /// امکانات که برای مثال شامل
        ///سیستم گرمایشی ، کولر 
        /// </summary>
        [Display(Name = "امکانات")]
        public string OptionIdsJson { get; set; }

        public List<int> OptionIds { get; set; }

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
        [Required(ErrorMessage = "متراژ را وارد کنید")]
        [Range(1, long.MaxValue, ErrorMessage = "مقدار وارد شده نامعتبر است")]
        public int Scale { get; set; }

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
        public string Floor { get; set; }


        public int? UserId { get; set; }


        [Display(Name = "نوع ملک")]
        public int? CategoryId { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.Now;


    }
}
