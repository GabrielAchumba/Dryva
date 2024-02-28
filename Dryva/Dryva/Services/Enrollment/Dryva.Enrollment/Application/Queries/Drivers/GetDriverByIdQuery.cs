using Dryva.Enrollment.DTOs.Driver;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Application.Queries
{
    public class GetDriverByIdQuery : IRequest<DriverDataDTO>
    {
        public Guid Id { get;  }
        public GetDriverByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
