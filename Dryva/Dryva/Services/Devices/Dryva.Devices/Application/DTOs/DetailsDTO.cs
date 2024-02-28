using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Devices.DTOs
{
    public class DetailsDTO : BaseDTO
    {
        public string SerialNumber { get; set; }
        public int Terminal { get; set; }

        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public char EW { get; set; }
        public char NS { get; set; }
        public float? Speed { get; set; }
        public float? Course { get; set; }
        public Guid RouteId { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
