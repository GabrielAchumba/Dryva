using System;

namespace CustomerSubscription.API.Application.Dtos {
    public class SubscriberTripsDetailDto {
        public long CardSerialNumber { get; set; }

        public Guid CustomerId { get; set; }
        
        public int AvailableTrips { get;  set; }

        /// <summary>
        /// Amount left for trips
        /// </summary>
        public double DepleteAmount { get; set; }

    }
}