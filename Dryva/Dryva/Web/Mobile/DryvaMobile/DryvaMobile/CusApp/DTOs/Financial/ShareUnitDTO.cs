using System;
using System.Collections.Generic;
using System.Text;

namespace CusApp.DTOs.Financial
{
    public class ShareUnitDTO
    {
        public Guid CustomerId { get; set; }
        public DateTime DateofShared { get; set; }

        public int Trips { get; set; }

        public long? Csn { get; set; }
    }
}
