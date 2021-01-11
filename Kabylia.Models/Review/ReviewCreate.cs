using Kabylia.Models.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Models.Review
{
    public class ReviewCreate
    {
        
        public string Reviews { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
    }
}
