using System;
using System.Collections.Generic;
using System.Text;

namespace Amlak.Core.DTO.House
{
    public class HouseSearchDto
    {

        /// <summary>
        /// وضیعت
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// قیمت
        /// </summary>
        public long Price { get; set; }

        /// <summary>
        /// تعداد اتاق
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
        public string OptionIdsJson { get; set; }

        /// <summary>
        /// متراژ ملک
        /// </summary>
        public int Scale { get; set; }

        /// <summary>
        /// منطفه
        /// </summary>

        /// <summary>
        /// شهر
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// استان
        /// </summary>
        public string Town { get; set; }


        /// <summary>
        /// محله
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// طبقه 
        ///  </summary>
        public string Floor { get; set; }
        public int? CategoryId { get; set; }
    }
}
