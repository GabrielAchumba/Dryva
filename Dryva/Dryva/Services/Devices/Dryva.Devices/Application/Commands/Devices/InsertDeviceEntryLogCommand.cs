using Dryva.Devices.DTOs;
using MediatR;

namespace Dryva.Devices.Application.Commands
{
    public class InsertDeviceEntryLogCommand : IRequest<EntryTransitLogDTO>
    {
        public EntryTransitLogDTO Model { get; }

        public InsertDeviceEntryLogCommand(EntryTransitLogDTO model)
        {
            Model = model;
        }
    }
}
