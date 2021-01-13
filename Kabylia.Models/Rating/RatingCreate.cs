using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Models.Rating
{
   public class RatingCreate
    {
        public int RestaurantRating { get; set; }
        public string RestaurantName { get; set; }
        public int DeliveryDriverRating { get; set; }
        public string DeliveryDriverName { get; set; }
        public int RestaurantId { get; set; }
        public int DeliveryDriverId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
    }
}
