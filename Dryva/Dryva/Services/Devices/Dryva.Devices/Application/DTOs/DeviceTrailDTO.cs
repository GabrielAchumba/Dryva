using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Devices.DTOs
{
    public class DeviceTrailDTO
    {
        public int Terminal { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public char EW { get; set; }
        public char NS { get; set; }
        public float? Speed { get; set; }
        public float? Course { get; set; }

        public Guid? DeviceId { get; set; }
        public DateTime GpsModifiedOn { get; set; }
    }
}
