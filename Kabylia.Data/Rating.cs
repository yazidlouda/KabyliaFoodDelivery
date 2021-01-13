using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Data
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int RestaurantRating { get; set; }
        public int DeliveryDriverRating { get; set; }
        public int RestaurantId { get; set; }
        public int DeliveryDriverId { get; set; }
        public int CustomerId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual DeliveryDriver DeliveryDriver { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
