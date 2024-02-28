using Dryva.Enrollment.DTOs.Investor;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Application.Queries
{
    public class GetRTPSByIdQuery : IRequest<InvestorDTO>
    {
        public Guid Id { get;  }
        public GetRTPSByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
