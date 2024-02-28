using System;

namespace Dryva.VendorSubscription.API.ResourceParameters
{
    public class DateRangeParameter
    {
        public DateTimeOffset BeginDate { get; set; }

        public DateTimeOffset EndDate { get; set; }
    }
}
