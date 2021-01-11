using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Models.Review
{
    public class ReviewListItem
    {
        public int ReviewId { get; set; }
        public string Reviews { get; set; }
        public string CustomerName { get; set; }
        public string RestaurantName { get; set; }
    }
}
