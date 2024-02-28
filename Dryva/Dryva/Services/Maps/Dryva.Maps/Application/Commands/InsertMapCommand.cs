using Dryva.Maps.DTOs;
using MediatR;

namespace Dryva.Maps.Application.Commands
{
    public class InsertMapCommand : IRequest<MapAxisDTO>
    {
        public NewMapAxisDTO Model { get; }

        public InsertMapCommand(NewMapAxisDTO model)
        {
            Model = model;
        }
    }
}
