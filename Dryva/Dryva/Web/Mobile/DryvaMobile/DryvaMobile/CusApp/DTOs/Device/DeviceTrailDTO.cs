using System;
using System.Collections.Generic;
using System.Text;

namespace CusApp.DTOs.Device
{
    public class DeviceTrailDTO : BaseDTO
    {
        
        public int Terminal { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public char EW { get; set; }
        public char NS { get; set; }
        public float? Speed { get; set; }
        public float? Course { get; set; }

        public Guid? DeviceId { get; set; }
        public DateTime GpsModifiedOn { get; set; }

        
    }
}
