using Kabylia.Data;
using Kabylia.Models.Customer;
using Kabylia.Models.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Models.Restaurant
{
   public class RestaurantDetails
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
        // public List<Customer> Customer { get; set; }
        //public int MenuId { get; set; }
        //public string MenuName { get; set; }
        public int NumberOfMenu { get; set; }
        public bool Select { get; set; }
        public List<MenuListItem> Menu { get; set; } = new List<MenuListItem>();
        //public List<CustomerListItem> Customer { get; set; } = new List<CustomerListItem>();

    }
}
