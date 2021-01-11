using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Data
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string Reviews { get; set; }
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
