﻿using System;
using System.Collections.Generic;

namespace CustomerSubscription.API.HealthChecks {
    public class HealthCheckResponse {
        public string Status { get; set; }

        public IEnumerable<HealthCheck> Checks { get; set; }

        public TimeSpan TotalDuration { get; set; }
    }
}