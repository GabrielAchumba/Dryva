using Dryva.Enrollment.DTOs.Customer;
using MediatR;

namespace Dryva.Enrollment.Application.Handlers
{
    public class InsertCustomerRegistrationDataCommand : IRequest<CustomerRegistrationDTO>
    {
        public NewCustomerRegistrationDTO Customer { get; }

        public InsertCustomerRegistrationDataCommand(NewCustomerRegistrationDTO model)
        {
            Customer = model;
        }
    }
}
