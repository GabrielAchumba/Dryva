using Dryva.Enrollment.DTOs.Customer;
using MediatR;
using System;

namespace Dryva.Enrollment.Application.Handlers
{
    public class UpdateCustomerRegistrationDataCommand : IRequest<CustomerRegistrationDTO>
    {
        public NewCustomerRegistrationDTO Customer { get; }
        public Guid Id { get; }

        public UpdateCustomerRegistrationDataCommand(NewCustomerRegistrationDTO model, Guid id)
        {
            Customer = model;
            Id = id;
        }
    }
}
