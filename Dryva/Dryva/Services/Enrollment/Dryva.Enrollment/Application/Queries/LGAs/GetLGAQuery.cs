using Dryva.Enrollment.DTOs.Lga;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Application.Queries
{
    public class GetLGAQuery : IRequest<IEnumerable<LGADTO>>
    {
       
    }
}
