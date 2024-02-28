using Dryva.Devices.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Devices.Application.Queries
{
    public class GetDeviceTransitLogsByCSNQuery : IRequest<IEnumerable<TransitLogDetailsDTO>>
    {
        public int CSN { get;  }
        public GetDeviceTransitLogsByCSNQuery(int csn)
        {
            CSN = csn;
        }
    }
}
