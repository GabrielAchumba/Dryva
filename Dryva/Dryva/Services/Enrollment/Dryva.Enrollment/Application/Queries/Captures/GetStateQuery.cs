using Dryva.Enrollment.DTOs.CaptureSession;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Application.Queries
{
    public class GetCaptureSessionQuery : IRequest<IEnumerable<CaptureSessionDTO>>
    {
       
    }
}
