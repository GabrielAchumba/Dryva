using Dryva.Maps.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Maps.Application.Queries
{
    public class GetMapByIdQuery : IRequest<MapAxisDTO>
    {
        public Guid Id { get;  }
        public GetMapByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
