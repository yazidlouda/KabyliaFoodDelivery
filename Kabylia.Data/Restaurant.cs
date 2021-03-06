﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Data
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
        public int AreaId { get; set; }
        public virtual Area Area { get; set; }
       // public string Review { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public virtual List<Menu> Menu { get; set; } = new List<Menu>();
        public virtual List<Review> Review { get; set; } = new List<Review>();
        public virtual List<Rating> Rating { get; set; } = new List<Rating>();
        [DefaultValue(false)]
        public bool IsStarred { get; set; }
        // public int MenuId { get; set; }
        //public virtual Menu Menu { get; set; }
        //public virtual List<Customer> Customer { get; set; } = new List<Customer>();

        //public Order Order {get;set;}
        //public Payment payment { get; set; }
        //public Location Location { get; set; }
        //Public Rating CutomerRationg {get;set;}
        //Public FoodCategory Category{get;set;}

    }
}
