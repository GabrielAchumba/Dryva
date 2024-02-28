using Dryva.Devices.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Devices.Application.Queries
{
    public class GetDeviceTrailsByTerminalQuery : IRequest<IEnumerable<DeviceTrailDTO>>
    {
        public int Terminal { get;  }
        public GetDeviceTrailsByTerminalQuery(int terminal)
        {
            Terminal = terminal;
        }
    }
}
