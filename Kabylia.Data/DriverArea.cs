using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Data
{
    public class DriverArea
    {
        public int DriverAreaId { get; set; }
        public DeliveryDriver DeliveryDriverId { get; set; }
        public Area AreaId { get; set; }
    }
}
