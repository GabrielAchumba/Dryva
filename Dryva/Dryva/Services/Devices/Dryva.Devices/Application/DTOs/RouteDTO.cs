using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Devices.DTOs
{
    public class RouteDTO : NewRouteDTO
    {
        public Guid Id { get; set; }
    }

    public class NewRouteDTO
    {
        public string Source { get; set; }
        public string Destination { get; set; }

        public string RoutePath { get { return $"{this.Source} To {this.Destination}"; } }
    }
}
