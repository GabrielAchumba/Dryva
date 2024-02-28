using Dryva.Enrollment.DTOs.Customer;
using MediatR;
using System;

namespace Dryva.Enrollment.Application.Commands
{
    public class DeleteShareholdersCommand : IRequest<int>
    {
        public Guid Id { get; }

        public DeleteShareholdersCommand( Guid id)
        {
            Id = id;
        }
    }
}
