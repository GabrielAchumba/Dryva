using Dryva.Enrollment.DTOs.Lga;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Application.Queries
{
    public class GetLGAByStateIdQuery : IRequest<IEnumerable<LGADTO>>
    {
        public Guid StateId { get;  }
        public GetLGAByStateIdQuery(Guid stateId)
        {
            StateId = stateId;
        }
    }
}
