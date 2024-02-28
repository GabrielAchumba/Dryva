using System;

namespace Dryva.Devices.Models
{
    public class ExitTransitLog : EntityBase
    {
        public long LogId { get; set; }
        public int RechargeCode { get; set; }
        public int UnitsLeft { get; set; }
        public long Csn { get; set; }
        public int Terminal { get; set; }

        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public char LongEW { get; set; }
        public char LatNS { get; set; }
        public DateTime? Time { get; set; }
    }
}
