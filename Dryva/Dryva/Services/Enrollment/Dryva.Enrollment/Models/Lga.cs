using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Models
{
    public class Lga : EntityBase
    {
        public string Name { get; set; }

        public Guid StateId { get; set; }
        public string StateName { get; set; }
    }
}
