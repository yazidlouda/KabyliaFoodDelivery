using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Models.Area
{
    public class AreaCreate
    {

        [Required(ErrorMessage = "Area Name is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Enter a Valid  Area Name")]
        [RegularExpression(@"^[a-zA-Z ]*[a-zA-Z]", ErrorMessage = "Area Name Should Contain Alphabets Only")]
        public string AreaName { get; set; }
    }
}
