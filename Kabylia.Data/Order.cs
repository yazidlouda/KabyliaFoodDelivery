using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Data
{
   public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string Menu { get; set; }
        public double Price { get; set; }
        public DateTime DateOfOrder { get; set; }
        public double DeliveryCharge { get; set; }
    }
}
