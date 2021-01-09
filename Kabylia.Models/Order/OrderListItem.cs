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
        public RestaurantDetails Restaurant { get; set; } = new RestaurantDetails();
        public double RestaurantLatitude { get; set; }
        public double RestaurantLongitude { get; set; }
        public double CustomerLatitude { get; set; }
        public double CustomerLongitude { get; set; }
        public double DriverLatitude { get; set; }
        public double DriverLongitude { get; set; }
        public double Amount { get; set; }
    }
}
