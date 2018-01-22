using System;
using System.ComponentModel.DataAnnotations;

namespace Amlak.Core.ViewModel.News
{
    public class NewsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public string File { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool IsPublished { get; set; } = false;
    }
}
