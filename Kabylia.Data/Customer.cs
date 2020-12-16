using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Data
{
    public enum ContactPreference { Phone = 1, text, Email }
    public class Customer
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

        //public Restaurant FavortiteRestaurant {get;set;}
        //public Payment Payment {get;set;}
        //Public FoodCategory Category {get;set;}
        //public Order Order {get;set;}
    }
}
