using Kabylia.Data;
using Kabylia.Models.Menu;
using Kabylia.Models.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Models.Order
{
   public class OrderDetails
    {
        public int OrderId { get; set; }
        //public string Menu { get; set; }
        public double Price { get; set; }
        public DateTime DateOfOrder { get; set; }
        public double DeliveryCharge { get; set; }
       // public int CustomerId { get; set; }
        public string CustomerName { get; set; }
      //  public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string DriverName { get; set; }

        //public List<Menu> Menu { get; set; }
        public List<MenuListItem> Menu { get; set; } = new List<MenuListItem>();


    }
}
