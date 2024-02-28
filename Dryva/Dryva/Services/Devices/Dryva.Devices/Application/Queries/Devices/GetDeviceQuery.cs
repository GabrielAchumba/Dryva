using Dryva.Devices.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Devices.Application.Queries
{
    public class GetDeviceQuery : IRequest<IEnumerable<DetailsDTO>>
    {
    }
}
