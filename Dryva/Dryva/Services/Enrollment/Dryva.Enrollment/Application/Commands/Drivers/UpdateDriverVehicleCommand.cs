using Dryva.Enrollment.DTOs.Driver;
using MediatR;
using System;

namespace Dryva.Enrollment.Application.Handlers
{
    public class UpdateDriverVehicleCommand : IRequest<DriverVehicleDTO>
    {
        public NewDriverVehicleDTO Driver { get; }
        public Guid Id { get; }

        public UpdateDriverVehicleCommand(NewDriverVehicleDTO model, Guid id)
        {
            Driver = model;
            Id = id;
        }
    }
}
