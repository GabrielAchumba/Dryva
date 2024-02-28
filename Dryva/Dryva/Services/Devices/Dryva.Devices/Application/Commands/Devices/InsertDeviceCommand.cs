using Dryva.Devices.DTOs;
using MediatR;

namespace Dryva.Devices.Application.Commands
{
    public class InsertDeviceCommand : IRequest<DeviceDTO>
    {
        public NewDeviceDTO Model { get; }

        public InsertDeviceCommand(NewDeviceDTO model)
        {
            Model = model;
        }
    }
}
