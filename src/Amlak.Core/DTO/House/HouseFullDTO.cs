﻿using System;
using System.Collections.Generic;
using System.Text;
using Amlak.Core.Entities;

namespace Amlak.Core.DTO.House
{
    public class HouseFullDTO
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
        public string OptionIdsJson { get; set; }

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
        /// منطفه
        /// </summary>
        public string Region { get; set; }

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
        public int Floor { get; set; }

        /// <summary>
        /// پیشنهاد ویژه
        /// </summary>
        public bool IsSpecialOffer { get; set; }

        /// <summary>
        /// زمان ثبت آگهی
        /// </summary>
        public DateTime RequestDate { get; set; }

        /// <summary>
        ///زمان انتشار آگاهی که توسط ادمین تهیین میشود 
        /// </summary>
        public DateTime? PublishDate { get; set; }

        public bool IsPublished { get; set; }


        public int? UserId { get; set; }
        public int? CategoryId { get; set; }


        public virtual Category Category { get; set; }

    }
}