﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Models.Menu
{
    public class MenuEdit
    {
        public int MenuId { get; set; }
        [Display(Name = "Category Name")]
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int RestaurantId { get; set; }
        public bool Select { get; set; }

    }
}
