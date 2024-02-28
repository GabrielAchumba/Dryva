using Dryva.Devices.DTOs;
using MediatR;
using System;

namespace Dryva.Devices.Application.Commands
{
    public class UpdateDeviceCommand : IRequest<DeviceDTO>
    {
        public NewDeviceDTO Model { get; }
        public Guid Id { get; }

        public UpdateDeviceCommand(NewDeviceDTO model, Guid id)
        {
            Model = model;
            Id = id;
        }
    }
}
