using Dryva.Enrollment.DTOs.CaptureSession;
using MediatR;
using System;

namespace Dryva.Enrollment.Application.Commands
{
    public class UpdateFingerprintsSessionCommand : IRequest<UpdateFingerprintsSessionDTO>
    {
        public NewUpdateFingerprintsSessionDTO Model { get; }
        public Guid Id { get; }

        public UpdateFingerprintsSessionCommand(NewUpdateFingerprintsSessionDTO model, Guid id)
        {
            Model = model;
            Id = id;
        }
    }
}
