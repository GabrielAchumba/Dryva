using Dryva.Maps.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Maps.Application.Queries
{
    public class GetMapByLocationQuery : IRequest<MapAxisDTO>
    {
        public float Latitude { get; }
        public float Longitude { get; }
        public GetMapByLocationQuery( float longitude, float latitude)
        {
            this.Longitude = longitude;
            this.Latitude = latitude;
        }
    }
}
