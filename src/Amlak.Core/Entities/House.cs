using System;
using System.Collections.Generic;
using System.Text;

namespace Amlak.Core.Entities
{
   public class House
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        
        /// <summary>
        /// وضیعت
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// قیمت
        /// </summary>
        public long Price { get; set; }

        /// <summary>
        /// تعداد اطاق
        /// </summary>
        public int Rooms { get; set; }

        /// <summary>
        /// تعداد حمام
        /// </summary>
        public int Bathrooms { get; set; }

        /// <summary>
        /// تعداد پارکینگ
        /// </summary>
        public int Parkings { get; set; }

        /// <summary>
        /// امکانات که برای مثال شامل
        ///سیستم گرمایشی ، کولر 
        /// </summary>
        public string PossibilitiesIdsJson{ get; set; }


        /// <summary>
        /// مکان جغرافیای
        /// </summary>
        public string Loacation { get; set; }


        /// <summary>
        /// تصاویر ملک
        /// </summary>
        public string PhotoGalleryJson { get; set; }

        /// <summary>
        /// متراژ ملک
        /// </summary>
        public string Scale { get; set; }

        /// <summary>
        /// محله
        /// </summary>
        public string Region{ get; set; }

        /// <summary>
        /// طبقه 
        ///  </summary>
        public int Floor { get; set; }

        public int? UserId { get; set; }
        public int? CategoryId { get; set; }



        public virtual Category Category { get; set; }
        public virtual User User { get; set; }

    }
 }
