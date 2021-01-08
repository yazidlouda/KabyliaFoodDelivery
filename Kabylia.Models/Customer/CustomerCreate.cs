using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Models.Customer
{
    public class CustomerCreate
    {
      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public ContactPreference ContactPreference { get; set; }
        public int MembershipLevel { get; set; }
        //public int RestaurantId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        //public Restaurant FavortiteRestaurant {get;set;}
        //public Payment Payment {get;set;}
        //Public FoodCategory Category {get;set;}
        //public Order Order {get;set;}
    }
}
