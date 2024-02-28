using Dryva.Enrollment.DTOs.Driver;
using MediatR;
using System;

namespace Dryva.Enrollment.Application.Handlers
{
    public class UpdateDriverOwnerNOKCommand : IRequest<DriverOwnerNOKDTO>
    {
        public NewDriverOwnerNOKDTO Driver { get; }
        public Guid Id { get; }

        public UpdateDriverOwnerNOKCommand(NewDriverOwnerNOKDTO model, Guid id)
        {
            Driver = model;
            Id = id;
        }
    }
}
