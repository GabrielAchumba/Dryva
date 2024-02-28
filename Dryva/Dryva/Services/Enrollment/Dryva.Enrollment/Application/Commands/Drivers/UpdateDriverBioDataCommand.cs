using Dryva.Enrollment.DTOs.Driver;
using MediatR;
using System;

namespace Dryva.Enrollment.Application.Handlers
{
    public class UpdateDriverBioDataCommand : IRequest<DriverBioDataDTO>
    {
        public NewDriverBioDataDTO Driver { get; }
        public Guid Id { get; }

        public UpdateDriverBioDataCommand(NewDriverBioDataDTO model, Guid id)
        {
            Driver = model;
            Id = id;
        }
    }
}
