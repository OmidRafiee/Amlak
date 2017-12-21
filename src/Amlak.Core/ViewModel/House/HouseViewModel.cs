using System;
using System.Collections.Generic;
using System.Text;

namespace Amlak.Core.ViewModel
{
    public class HouseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public string Status { get; set; }

        public long Price { get; set; }

        public int Rooms { get; set; }

        public int Bathrooms { get; set; }

        public int Parkings { get; set; }

        public string PossibilitiesIdsJson { get; set; }

        public string Loacation { get; set; }


        public string PhotoGalleryJson { get; set; }

        public string Scale { get; set; }

        public int? CategoryId { get; set; }
        public int? UserId { get; set; }
    }
}
