using Dryva.Maps.DTOs;
using MediatR;
using System;

namespace Dryva.Maps.Application.Commands
{
    public class UpdateMapCommand : IRequest<MapAxisDTO>
    {
        public NewMapAxisDTO Model { get; }
        public Guid Id { get; }

        public UpdateMapCommand(NewMapAxisDTO model, Guid id)
        {
            Model = model;
            Id = id;
        }
    }
}
