using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Devices.DTOs
{
    public class GPSInfo
    {
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public char EW { get; set; }
        public char NS { get; set; }
        public DateTime Time { get; set; }
    }

    public class TransitLogDetailsDTO
    {
        public long LogId { get; set; }
        public long Csn { get; set; }
        public int Terminal { get; set; }

        public GPSInfo Entry { get; set; }
        public GPSInfo Exit { get; set; }
    }
}
