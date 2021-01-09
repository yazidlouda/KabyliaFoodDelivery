using Kabylia.Data;
using Kabylia.Models.Menu;
using Kabylia.Models.Restaurant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Models.Order
{
   public class OrderCreate
    {
        //public int OrderId { get; set; }
        //public string Menu { get; set; }
        public double Price { get; set; }
       // public DateTime DateOfOrder { get; set; }
        public double DeliveryCharge { get; set; }
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        [Display(Name = "Restaurant")]
        public int RestaurantId { get; set; }
        [Display(Name = "Driver")]
        public int DriverId { get; set; }
        public RestaurantDetails Restaurant { get; set; } = new RestaurantDetails();

        // public  string RestaurantName { get; set; }
        //public List<Menu> Menu { get; set; }

    }
}
