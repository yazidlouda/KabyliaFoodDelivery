using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Models.Restaurant
{
   public class RestaurantListItem
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
        public string Area { get; set; }
        public string Review { get; set; }
        public List<string> Menu { get; set; }
    }
}
