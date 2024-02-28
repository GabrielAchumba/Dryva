using System;

namespace CustomerSubscription.API.ResourceParameters
{
    public class SubscriptionParameters
    {
        public Guid CustomerId { get; set; }

        public long CardSerialNumber { get; set; }
    }
}
