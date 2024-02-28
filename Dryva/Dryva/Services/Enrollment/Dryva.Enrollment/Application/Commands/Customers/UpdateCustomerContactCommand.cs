using Dryva.Enrollment.DTOs.Customer;
using MediatR;
using System;

namespace Dryva.Enrollment.Application.Handlers
{
    public class UpdateCustomerContactCommand : IRequest<CustomerContactDTO>
    {
        public NewCustomerContactDTO Customer { get; }
        public Guid Id { get; }

        public UpdateCustomerContactCommand(NewCustomerContactDTO model, Guid id)
        {
            Customer = model;
            Id = id;
        }
    }
}
