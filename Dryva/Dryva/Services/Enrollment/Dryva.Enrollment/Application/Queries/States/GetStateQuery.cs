using Dryva.Enrollment.DTOs.State;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Application.Queries
{
    public class GetStateQuery : IRequest<IEnumerable<StateDTO>>
    {
       
    }
}
