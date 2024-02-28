using System;

namespace Dryva.VendorSubscription.API.Application.Models
{
    public class VendorSubscription
    {
        public VendorSubscription()
        {
            SubscriptionId = Guid.NewGuid();
        }
        public Guid SubscriptionId { get; set; }

        public Guid VendorId { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset ModifiedOn { get; set; }

        public long RechargeCode { get; set; }

        public decimal Amount { get; set; }

        public decimal DepleteAmount { get; set; }

        public string TransactionCode { get; set; }

        public bool IsActive { get; set; }
    }
}
