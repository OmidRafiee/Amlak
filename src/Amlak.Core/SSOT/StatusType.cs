using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Amlak.Core.SSOT
{
    public enum StatusType
    {
        [Display(Name = "فروش")]
        Sale ,

        [Display(Name = "رهن")]
        Mortgage,

        [Display(Name = "اجاره")]
        Rent ,

    }


    public enum StatusSearchType
    {
        [Display(Name = "خرید")]
        Sale = 1,

        [Display(Name = "رهن")]
        Mortgage = 2,

        [Display(Name = "اجاره")]
        Rent = 3,

    }
}
