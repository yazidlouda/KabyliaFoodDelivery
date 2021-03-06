﻿using Kabylia.Models.Customer;
using Kabylia.Models.Order;
using Kabylia.Models.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Models.DeliveryDriver
{
    public class DeliveryDriverDetails
    {
        public int DriverId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string FullName { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int DelivryCount { get; set; }
        public List<OrderListItem> Order { get; set; } = new List<OrderListItem>();
        public OrderListItem Orders { get; set; }= new OrderListItem();
       
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        //public int DeliveryCount { get; set; }
    }
}
