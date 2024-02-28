using Dryva.Enrollment.DTOs.Customer;
using MediatR;
using System;

namespace Dryva.Enrollment.Application.Handlers
{
    public class DeleteDriverCommand : IRequest<int>
    {
        public Guid Id { get; }

        public DeleteDriverCommand( Guid id)
        {
            Id = id;
        }
    }
}
