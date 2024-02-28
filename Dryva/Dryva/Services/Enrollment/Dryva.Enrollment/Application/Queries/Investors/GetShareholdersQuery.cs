using Dryva.Enrollment.DTOs.Investor;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Application.Queries
{
    public class GetShareholdersQuery : IRequest<IEnumerable<InvestorDTO>>
    {
       
    }
}
