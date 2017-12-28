using System;
using System.ComponentModel.DataAnnotations;

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

        
        [Display(Name = "قیمت")]
        public long Price { get; set; }

       
        [Display(Name = "تعدا اتاق")]
        public int Rooms { get; set; }

       
        [Display(Name = "تعداد حمام")]
        public int Bathrooms { get; set; }

      
        [Display(Name = "تعداد پارکینگ")]
        public int Parkings { get; set; }

       
        [Display(Name = "امکانات")]
        public string PossibilitiesIdsJson { get; set; }

        
        [Display(Name = "مکان جغرافیایی")]
        public string Loacation { get; set; }

       
        [Display(Name = "تصاویر ملک")]
        public string PhotoGalleryJson { get; set; }

        
        [Display(Name = "متراژ")]
        public string Scale { get; set; }

       
        [Display(Name = "منطقه")]
        public string Region { get; set; }

        
        [Display(Name = "شهر")]
        public string City { get; set; }

        
        [Display(Name = "استان")]
        public string Town { get; set; }

        
        [Display(Name = "محله")]

        public string Area { get; set; }

      
        [Display(Name = "طبقه")]
        public int Floor { get; set; }


        public int? UserId { get; set; }

        [Display(Name = "نوع ملک")]
        public int? CategoryId { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.Now;

        public DateTime? PublishDate { get; set; }
        public bool IsPublished { get; set; }
        public bool IsSpecialOffer { get; set; }


    }
}
