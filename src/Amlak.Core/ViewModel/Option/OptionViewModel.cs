using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Amlak.Core.ViewModel.Option
{
    public class OptionViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "عنوان امکانات را وارد نمایید")]
        [Display(Name = "عنوان امکانات")]
        public string Title { get; set; }
    }
}
