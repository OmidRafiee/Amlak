using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Amlak.Core.Entities
{
    public class Pages
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Basename { get; set; }
        public string Body { get; set; }
        public bool IsPublished { get; set; }
    }
}
