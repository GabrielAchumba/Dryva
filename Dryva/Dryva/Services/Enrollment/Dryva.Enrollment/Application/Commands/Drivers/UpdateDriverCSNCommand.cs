using Dryva.Enrollment.DTOs.Driver;
using MediatR;
using System;

namespace Dryva.Enrollment.Application.Handlers
{
    public class UpdateDriverCSNCommand : IRequest<DriverCSNDTO>
    {
        public NewDriverCSNDTO Driver { get; }
        public Guid Id { get; }

        public UpdateDriverCSNCommand(NewDriverCSNDTO model, Guid id)
        {
            Driver = model;
            Id = id;
        }
    }
}
