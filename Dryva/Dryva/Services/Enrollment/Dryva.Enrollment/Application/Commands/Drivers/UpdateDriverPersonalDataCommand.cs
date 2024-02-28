using Dryva.Enrollment.DTOs.Driver;
using MediatR;
using System;

namespace Dryva.Enrollment.Application.Handlers
{
    public class UpdateDriverPersonalDataCommand : IRequest<DriverPersonalDataDTO>
    {
        public NewDriverPersonalDataDTO Driver { get; }
        public Guid Id { get; }

        public UpdateDriverPersonalDataCommand(NewDriverPersonalDataDTO model, Guid id)
        {
            Driver = model;
            Id = id;
        }
    }
}
