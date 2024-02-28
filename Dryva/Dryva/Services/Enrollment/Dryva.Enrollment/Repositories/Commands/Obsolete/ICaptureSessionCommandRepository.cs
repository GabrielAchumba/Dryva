using Dryva.Enrollment.DTOs.CaptureSession;
using System;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Repositories.Commands
{
    public interface ICaptureSessionCommandRepository
    {
        Task<int> Delete(Guid id);
        Task<int> Insert(CaptureSessionDTO captureSessionDTO);
        Task<int> Update(UpdateFingerprintsSessionDTO updateFingerprintsDTO);
        Task<int> Update(UpdatePhotographSessionDTO captureSessionDTO);
    }
}