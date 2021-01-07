using Kabylia.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Models.Restaurant
{
   public class RestaurantListItem
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public string Review { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int NumberOfMenu { get; set; }
       
        // public string MenuName { get; set; }
        //public int MenuId { get; set; }
    }
}
