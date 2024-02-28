using Dryva.Enrollment.DTOs.Customer;
using MediatR;
using System;

namespace Dryva.Enrollment.Application.Handlers
{
    public class DeleteCustomerCommand : IRequest<int>
    {
        public Guid Id { get; }

        public DeleteCustomerCommand( Guid id)
        {
            Id = id;
        }
    }
}
