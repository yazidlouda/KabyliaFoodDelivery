using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Models.Menu
{
    public class MenuListItem
    {
        [Display(Name = "Menu ID")]
        public int MenuId { get; set; }
        [Display(Name = "Menu Name")]
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string RestaurantName { get; set; }
        public int RestaurantId { get; set; }
    }
}
