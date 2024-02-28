using Dryva.Devices.DTOs;
using MediatR;

namespace Dryva.Devices.Application.Commands
{
    public class InsertDeviceExitLogCommand : IRequest<ExitTransitLogDTO>
    {
        public ExitTransitLogDTO Model { get; }

        public InsertDeviceExitLogCommand(ExitTransitLogDTO model)
        {
            Model = model;
        }
    }
}
