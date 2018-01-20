using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Amlak.Core.SSOT;

namespace Amlak.Core.ViewModel.House
{
    public class HouseEditViewModel
    {
        public int Id { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "عنوان ملک را وارد نمایید", AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }


        [Display(Name = "وضیعت")]
        public string Status { get; set; }

        [Display(Name = " قیمت (ريال)")]
        [Required(ErrorMessage = "قیمت را وارد کنید")]
        [Range(1, long.MaxValue, ErrorMessage = "مقدار وارد شده نامعتبر است")]
        public long Price { get; set; }


        [Display(Name = "تعدا اتاق")]
        [Range(0, long.MaxValue, ErrorMessage = "مقدار وارد شده نامعتبر است")]
        public int Rooms { get; set; }


        [Display(Name = "تعداد حمام")]
        [Range(0, long.MaxValue, ErrorMessage = "مقدار وارد شده نامعتبر است")]
        public int Bathrooms { get; set; }


        [Display(Name = "تعداد پارکینگ")]
        [Range(0, long.MaxValue, ErrorMessage = "مقدار وارد شده نامعتبر است")]
        public int Parkings { get; set; }


        [Display(Name = "امکانات")]
        public string OptionIdsJson { get; set; }

        public List<int> OptionIds { get; set; }
        [Display(Name = "مکان جغرافیایی")]
        public string Loacation { get; set; }


        [Display(Name = "تصاویر ملک")]
        public string PhotoGalleryJson { get; set; }


        [Display(Name = "متراژ")]
        public int Scale { get; set; }


        [Display(Name = "منطقه")]
        public string Region { get; set; }


        [Display(Name = "شهر")]
        public string City { get; set; }


        [Display(Name = "استان")]
        public string Town { get; set; }


        [Display(Name = "محله")]
        public string Area { get; set; }

        [Display(Name = "طبقه")]
        public string Floor { get; set; }


        [Display(Name = "نوع ملک")]
        public int? CategoryId { get; set; }

        //public DateTime RequestDate { get; set; } = DateTime.Now;

        //public DateTime? PublishDate { get; set; }
        //public bool IsPublished { get; set; }
        //public bool IsSpecialOffer { get; set; }

    }
}
