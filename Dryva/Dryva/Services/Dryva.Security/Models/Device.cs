using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Security.Models
{
    public class Device : EntityBase
    {
        public string SerialNumber { get; set; }
        public int Terminal { get; set; }
        public string Class { get; set; }
        public bool Activated { get; set; }
    }
}
