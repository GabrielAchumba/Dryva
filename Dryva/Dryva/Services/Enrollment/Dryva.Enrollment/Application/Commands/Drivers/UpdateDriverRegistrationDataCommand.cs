using Dryva.Enrollment.DTOs.Driver;
using MediatR;
using System;

namespace Dryva.Enrollment.Application.Handlers
{
    public class UpdateDriverRegistrationDataCommand : IRequest<DriverRegistrationDTO>
    {
        public NewDriverRegistrationDTO Driver { get; }
        public Guid Id { get; }

        public UpdateDriverRegistrationDataCommand(NewDriverRegistrationDTO model, Guid id)
        {
            Driver = model;
            Id = id;
        }
    }
}
