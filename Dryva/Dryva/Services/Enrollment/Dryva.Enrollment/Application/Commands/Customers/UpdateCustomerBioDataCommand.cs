using Dryva.Enrollment.DTOs.Customer;
using MediatR;
using System;

namespace Dryva.Enrollment.Application.Handlers
{
    public class UpdateCustomerBioDataCommand : IRequest<CustomerBioDataDTO>
    {
        public NewCustomerBioDataDTO Customer { get; }
        public Guid Id { get; }

        public UpdateCustomerBioDataCommand(NewCustomerBioDataDTO model, Guid id)
        {
            Customer = model;
            Id = id;
        }
    }
}
