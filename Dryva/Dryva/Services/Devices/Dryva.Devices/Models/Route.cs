using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Devices.Models
{
    public class Route : EntityBase
    {
        public string Source { get; set; }
        public string Destination { get; set; }
    }
}
