using Dryva.Enrollment.DTOs.Customer;
using MediatR;
using System;

namespace Dryva.Enrollment.Application.Handlers
{
    public class UpdateCustomerCSNCommand : IRequest<CustomerCSNDTO>
    {
        public NewCustomerCSNDTO Customer { get; }
        public Guid Id { get; }

        public UpdateCustomerCSNCommand(NewCustomerCSNDTO model, Guid id)
        {
            Customer = model;
            Id = id;
        }
    }
}
