using Dryva.Enrollment.DTOs.CaptureSession;
using MediatR;
using System;

namespace Dryva.Enrollment.Application.Commands
{
    public class DeleteCaptureSessionCommand : IRequest<int>
    {
        public Guid Id { get; }

        public DeleteCaptureSessionCommand( Guid id)
        {
            Id = id;
        }
    }
}
