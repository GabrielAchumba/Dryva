using System;

namespace Dryva.VendorSubscription.API.Application.Models
{
    public class CustomerSubscription
    {
        public CustomerSubscription()
        {
            SubscriptionId = Guid.NewGuid();
        }

        public Guid SubscriptionId { get; set; }

        public Guid VendorId { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public decimal Amount { get; set; }

        public Guid CustomerId { get; set; }

        public long CardSerialNumber { get; set; }
    }
}
