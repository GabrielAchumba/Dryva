using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Devices.DTOs
{
    public class DeviceDTO : NewDeviceDTO
    {
        public Guid Id { get; set; }
    }

    public class NewDeviceDTO
    {
        public string SerialNumber { get; set; }
        public int Terminal { get; set; }
        public string Class { get; set; }
        public bool Activated { get; set; }
        public Guid RouteId { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
    }
}
