using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Security.DTOs
{
    public class DeviceAccountDTO : BaseDTO
    {
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public int Terminal { get; set; }
        public string CompanyName { get; set; }
    }
}
