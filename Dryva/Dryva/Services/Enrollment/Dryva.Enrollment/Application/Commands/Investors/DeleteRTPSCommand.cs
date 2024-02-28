using Dryva.Enrollment.DTOs.Customer;
using MediatR;
using System;

namespace Dryva.Enrollment.Application.Commands
{
    public class DeleteRTPSCommand : IRequest<int>
    {
        public Guid Id { get; }

        public DeleteRTPSCommand( Guid id)
        {
            Id = id;
        }
    }
}
