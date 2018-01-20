using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Amlak.Core.SSOT
{
    public enum FloorType
    {
        [Display(Name = "زیر زمین")]
        Under,

        [Display(Name = "هم کف")]
        Ground,

        [Display(Name = "طبقه اول")]
        F1 ,
        
        [Display(Name = "طبقه دوم")]
        F2,
        
        [Display(Name = "طبقه سوم")]
        F3,

        [Display(Name = "طبقه چهارم")]
        F4,

        [Display(Name = "طبقه پنجم")]
        F5,

        [Display(Name = "طبقه ششم به بالا")]
        F6,

    }
 }
