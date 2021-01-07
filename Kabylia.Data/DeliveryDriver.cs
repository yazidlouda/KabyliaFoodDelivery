using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Data
{
    public class DeliveryDriver
    {
        [Key]
        public int DriverId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int DeliveryCount { get; set; }
        public virtual List<Order> Order { get; set; } = new List<Order>();
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        //public Order Order {get;set;}
        //Public Schedul Schedule {get;set;}
        //public Payment payment { get; set; }
        //public Location Location { get; set; }
        //Public Rating CutomerRationg {get;set;}
        //public Restaurant ReastaurantLocation {get;set;}
    }
}
