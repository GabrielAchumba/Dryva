using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.VendorSubscription.API.Dtos
{
    public class VendorSubscriptionDto
    {
        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset ModifiedOn { get; set; }

        public long RechargeCode { get; set; }

        public decimal Amount { get; set; }

        public decimal DepleteAmount { get; set; }

        public string TransactionCode { get; set; }

        public bool IsActive { get; set; }
    }
}
