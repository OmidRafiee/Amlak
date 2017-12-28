using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Amlak.Core.ViewModel.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "عنوان گروه را وارد نمایید")]
        [Display(Name = "عنوان گروه")]
        public string Title { get; set; }

    }
}
