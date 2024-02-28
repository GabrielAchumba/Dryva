using System;

namespace CustomerSubscription.API.HealthChecks {
    public class HealthCheck {
        public string Status { get; set; }

        public string Component { get; set; }

        public string Description { get; set; }

        public TimeSpan Duration { get; set; }
    }
}