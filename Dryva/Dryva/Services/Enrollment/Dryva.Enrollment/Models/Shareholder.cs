using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Models
{
    public class Shareholder : EntityBase, IInvestor
    {
        public long Pin { get; set; }
        public string Title { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string OtherName { get; set; }
        public string Gender { get; set; }
        public long? Csn { get; set; }

        public decimal Percentage { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}
