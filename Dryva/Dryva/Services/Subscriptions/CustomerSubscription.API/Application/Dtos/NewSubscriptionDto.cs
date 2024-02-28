using System;

namespace CustomerSubscription.API.Application.Dtos {
    public class NewSubscriptionDto {
        public Guid CustomerId { get; set; }

        public long CardSerialNumber { get; set; }

        public double Amount { get; set; }
    }
}
