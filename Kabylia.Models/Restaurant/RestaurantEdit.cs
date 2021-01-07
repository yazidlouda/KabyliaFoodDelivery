using Kabylia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Models.Restaurant
{
   public class RestaurantEdit
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
        public int AreaId { get; set; }
        public string Review { get; set; }
        public int MenuId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
