using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Data
{
    public class MenuItem
    {
        public int MenuitemId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
       // public int MenuCatId { get; set; }

      
    }
}
