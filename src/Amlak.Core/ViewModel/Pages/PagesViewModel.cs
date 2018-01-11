using System.ComponentModel.DataAnnotations;

namespace Amlak.Core.ViewModel.Pages
{
    public class PagesViewModel
    {
        public int  Id { get; set; }

        [Required (ErrorMessage = "عنوان صفحه را وارد کنید")]
        public string Title { get; set; }

        public string BaseName { get; set; }

        public string Body { get; set; }

        public bool IsPublished { get; set; } = false;
    }
}
