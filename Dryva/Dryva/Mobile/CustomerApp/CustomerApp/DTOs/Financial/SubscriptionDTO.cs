using System;

namespace CustomerApp.DTOs.Financial
{
    public class SubscriptionDTO
    {
        public Guid SubscriptionId { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset ModifiedOn { get; set; }

        public string TransactionCode { get; set; }

        public bool IsActive { get; set; }

        //public long RechargeCode { get; set; }

        //public decimal Amount { get; set; }

        public decimal Amount { get; set; }

        public Guid CustomerId { get; set; }

        public long CardSerialNumber { get; set; }

        public int AvailableTrips { get; set; } 

        /// <summary>
        /// Amount left for trips
        /// </summary>
        public double DepleteAmount { get; set; }

    }
}
