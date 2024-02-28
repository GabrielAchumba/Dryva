using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Devices.DTOs
{
    public class CardStatusDTO
    {
        public int RechargeCode { get; set; }
        public int UnitsLeft { get; set; }
        public long Csn { get; set; }
    }
}
