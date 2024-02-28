using System;

namespace Dryva.VendorSubscription.API.ResourceParameters
{
    public class CustomerParameter
    {
        public Guid CustomerId { get; set; }

        public long CardSerialNumber { get; set; }
    }
}
