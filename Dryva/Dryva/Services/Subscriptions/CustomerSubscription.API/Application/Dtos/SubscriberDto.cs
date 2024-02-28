using System;

namespace CustomerSubscription.API.Application.Dtos
{
    public class SubscriberDto
    {
        public Guid CustomerId { get; set; }

        public long CardSerialNumber { get; set; }
    }
}
