using System;
using System.Collections.Generic;
using System.Text;

namespace Amlak.Core.DTO.Detail
{
   public class SearchDTO
    {
        public string Town { get; set; }
        public string City { get; set; }
        public int Region { get; set; }
        public string Area { get; set; }
        public int? CategoryId { get; set; }
        public int MinScale { get; set; }
        public int MaxScale { get; set; }
        public long MinPrice1 { get; set; }
        public long MinPrice2 { get; set; }
        public long MinPrice { get; set; }
        public long MaxPrice { get; set; }

        public List<string> OptionIds { get; set; }


    }
}
