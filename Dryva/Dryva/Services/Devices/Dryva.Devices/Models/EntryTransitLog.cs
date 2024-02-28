using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Devices.Models
{
    public class EntryTransitLog : EntityBase
    {
        public long LogId { get; set; }
        public int RechargeCode { get; set; }
        public int UnitsLeft { get; set; }
        public long Csn { get; set; }
        public int Terminal { get; set; }

        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public char EW { get; set; }
        public char NS { get; set; }
        public DateTime Time { get; set; }
    }
}
