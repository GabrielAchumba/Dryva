using Dryva.Devices.DTOs;
using MediatR;

namespace Dryva.Devices.Application.Commands
{
    public class InsertDeviceTrailCommand : IRequest<DeviceTrailDTO>
    {
        public DeviceTrailDTO Model { get; }

        public InsertDeviceTrailCommand(DeviceTrailDTO model)
        {
            Model = model;
        }
    }
}
