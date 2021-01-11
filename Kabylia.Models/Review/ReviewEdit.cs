using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Models.Review
{
   public class ReviewEdit
    {
        public int ReviewId { get; set; }
        public string Reviews { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
    }
}
