using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.VendorSubscription.API.Dtos
{
    public class NewVendorSubscriptionDto
    {
        public long RechargeCode { get; set; }

        public decimal Amount { get; set; }

        public string TransactionCode { get; set; }
    }
}
