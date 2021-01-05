using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Models.Menu
{
   public class MenuCreate
    {
        [Display(Name = "Menu Name")]
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        [Display(Name = "Restaurant")]
        public int RestaurantId { get; set; }
    }
}
