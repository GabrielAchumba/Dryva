using Dryva.Enrollment.DTOs.Driver;
using MediatR;
using System;

namespace Dryva.Enrollment.Application.Handlers
{
    public class UpdateDriverContactCommand : IRequest<DriverContactDTO>
    {
        public NewDriverContactDTO Driver { get; }
        public Guid Id { get; }

        public UpdateDriverContactCommand(NewDriverContactDTO model, Guid id)
        {
            Driver = model;
            Id = id;
        }
    }
}
