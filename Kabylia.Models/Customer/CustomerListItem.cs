﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kabylia.Data;
using Kabylia.Models.Restaurant;

namespace Kabylia.Models.Customer
{
    public enum ContactPreference { Phone = 1, text, Email }
    public class CustomerListItem
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public ContactPreference ContactPreference { get; set; }
        public int MembershipLevel { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        //public string RestaurantName { get; set; }

    }
}
