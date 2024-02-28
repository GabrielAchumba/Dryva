using Dryva.Enrollment.DTOs.CaptureSession;
using MediatR;
using System;

namespace Dryva.Enrollment.Application.Commands
{
    public class UpdatePhotographSessionCommand : IRequest<UpdatePhotographSessionDTO>
    {
        public NewUpdatePhotographSessionDTO Model { get; }
        public Guid Id { get; }

        public UpdatePhotographSessionCommand(NewUpdatePhotographSessionDTO model, Guid id)
        {
            Model = model;
            Id = id;
        }
    }
}
