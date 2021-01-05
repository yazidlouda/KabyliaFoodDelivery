using Kabylia.Data;
using Kabylia.Models.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Models.Order
{
    public class OrderListItem
    {
        public int OrderId { get; set; }
        //public string Menu { get; set; }
        public double Price { get; set; }
        public DateTime DateOfOrder { get; set; }
        public double DeliveryCharge { get; set; }
       // public int CustomerId { get; set; }
        public string CustomerName { get; set; }
       // public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string DriverName { get; set; }
        public string RestaurantAddress { get; set; }
        public string CustomerAddress { get; set; }
        // public List<Menu> Menu { get; set; }
        public virtual List<MenuListItem> Menu { get; set; } = new List<MenuListItem>();

    }
}
