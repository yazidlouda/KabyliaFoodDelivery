using Kabylia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Models.Order
{
    public class OrderEdit
    {
        public int OrderId { get; set; }
        public double DeliveryCharge { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public double RestaurantLatitude { get; set; }
        public double RestaurantLongitude { get; set; }
        public double CustomerLatitude { get; set; }
        public double CustomerLongitude { get; set; }
        public double DriverLatitude { get; set; }
        public double DriverLongitude { get; set; }

    }
}
