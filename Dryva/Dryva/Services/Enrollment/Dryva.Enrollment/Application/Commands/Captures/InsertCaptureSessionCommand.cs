using Dryva.Enrollment.DTOs.CaptureSession;
using MediatR;

namespace Dryva.Enrollment.Application.Commands
{
    public class InsertCaptureSessionCommand : IRequest<CaptureSessionDTO>
    {
        public NewCaptureSessionDTO Model { get; }

        public InsertCaptureSessionCommand(NewCaptureSessionDTO model)
        {
            Model = model;
        }
    }
}
