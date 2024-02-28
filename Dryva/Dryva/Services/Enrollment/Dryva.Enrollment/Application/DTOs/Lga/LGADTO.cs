using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.DTOs.Lga
{
  
    public class LGADTO : BaseDTO
    {
        public string Name { get; set; }

        public Guid StateId { get; set; }
        public string StateName { get; set; }
    }
}
