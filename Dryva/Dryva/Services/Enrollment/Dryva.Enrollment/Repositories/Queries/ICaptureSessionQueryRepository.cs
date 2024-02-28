using Dryva.Enrollment.DTOs.CaptureSession;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Repositories.Queries
{
    public interface ICaptureSessionQueryRepository
    {
        Task<CaptureSessionDTO> GetCaptureSession(Guid id);
        Task<IEnumerable<CaptureSessionDTO>> GetCaptureSessions();
    }
}