using Kabylia.Data;
using Kabylia.Models.Area;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Models.Restaurant
{
    public class RestaurantCreate
    {
        
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
        [Display(Name = "Area")]
        public int AreaId { get; set; }
        public string Review { get; set; }
        [Display(Name = "Menu")]
        public int? MenuId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<AreaListItem> Area = new List<AreaListItem>();
        //public List<string> Menu { get; set; }
        // public int MenuId { get; set; }

    }
}
