using Dryva.Devices.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Devices.Application.Queries
{
    public class GetDeviceTransitLogsByCsnAndTimeQuery : IRequest<IEnumerable<TransitLogDetailsDTO>>
    {
        public int CSN { get; }
        public DateTime? From { get; }
        public DateTime? To { get; }
        public GetDeviceTransitLogsByCsnAndTimeQuery(int csn, DateTime? from , DateTime? to )
        {
            CSN = csn;
            this.From = from;
            this.To = to;
        }
    }
}
