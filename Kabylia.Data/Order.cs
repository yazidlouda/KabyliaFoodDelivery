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
        public virtual List<Menu> Menu{ get; set; }
        public double Price { get; set; }
        public DateTime DateOfOrder { get; set; }
        public double DeliveryCharge { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public int DriverId { get; set; }
        public virtual DeliveryDriver DeliveryDriver { get; set; }
       // public virtual Menu Menus { get; set; }
        //public  List<Menu> Menu { get; set; }

    }
}
