using System;
using System.Collections.Generic;
using System.Text;

namespace Amlak.Core.DTO.News
{
    public class NewsDTO
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
