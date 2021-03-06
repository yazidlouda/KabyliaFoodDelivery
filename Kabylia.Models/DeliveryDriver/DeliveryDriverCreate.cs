﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Models.DeliveryDriver
{
    public class DeliveryDriverCreate
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string FullName { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int OrderId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        // public int DeliveryCount { get; set; }
    }
}
