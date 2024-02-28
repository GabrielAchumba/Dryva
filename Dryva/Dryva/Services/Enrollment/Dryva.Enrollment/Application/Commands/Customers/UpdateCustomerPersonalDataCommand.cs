using Dryva.Enrollment.DTOs.Customer;
using MediatR;
using System;

namespace Dryva.Enrollment.Application.Handlers
{
    public class UpdateCustomerPersonalDataCommand : IRequest<CustomerPersonalDataDTO>
    {
        public NewCustomerPersonalDataDTO Customer { get; }
        public Guid Id { get; }

        public UpdateCustomerPersonalDataCommand(NewCustomerPersonalDataDTO model, Guid id)
        {
            Customer = model;
            Id = id;
        }
    }
}
