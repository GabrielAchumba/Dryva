using Dryva.Enrollment.DTOs.Lga;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Application.Queries
{
    public class GetLGAByIdQuery : IRequest<LGADTO>
    {
        public Guid Id { get;  }
        public GetLGAByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
