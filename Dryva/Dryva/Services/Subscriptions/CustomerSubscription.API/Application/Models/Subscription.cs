using System;

namespace CustomerSubscription.API.Application.Models
{
    public class Subscription
    {
        public Subscription()
        {
            SubscriptionId = Guid.NewGuid();
            ModifiedOn = CreatedOn = DateTimeOffset.Now;
        }

        public Guid SubscriptionId { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset ModifiedOn { get; set; }

        public decimal Amount { get; set; }

        public decimal DepleteAmount { get; set; }

        public string TransactionCode { get; set; }

        public bool IsActive { get; set; }

        public long RechargeCode { get; set; }

        public Guid CustomerId { get; set; }

        public long CardSerialNumber { get; set; }

        public Guid VendorId { get; set; }

    }
}
