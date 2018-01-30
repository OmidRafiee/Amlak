using System;
using System.Collections.Generic;
using System.Text;

namespace Amlak.Core.DTO.Detail
{
   public class SearchDTO
    {
        public string Area { get; set; }
        public string City { get; set; }
        public int? CategoryId { get; set; }
        public int Rooms { get; set; }
        public int Bathrooms { get; set; }
        public string Status { get; set; }

        public string Town { get; set; }
        public string Region { get; set; }
        
      
        public int MinScale { get; set; }
        public int MaxScale { get; set; }
        public long MinMeterPrice { get; set; }
        public long MaxMeterPrice { get; set; }
        public long MinPrice { get; set; }
        public long MaxPrice { get; set; }

        public List<string> OptionIds { get; set; }


        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;

    }
}
