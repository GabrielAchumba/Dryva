using System;

namespace Dryva.VendorSubscription.API.Dtos
{
    public class CustomerSubscriptionDto
    {

        public CustomerSubscriptionDto()
        {
            CreatedOn = DateTimeOffset.Now;
        }

        public Guid SubscriptionId { get; set; }

        public Guid VendorId { get; set; }

        public DateTimeOffset CreatedOn { get; }

        public decimal Amount { get; set; }

        public Guid CustomerId { get; set; }

        public long CardSerialNumber { get; set; }
    }
}
