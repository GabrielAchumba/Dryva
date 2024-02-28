using Dryva.VendorSubscription.API.Dtos;
using MediatR;

namespace Dryva.VendorSubscription.API.Application.Commands
{
    public class NewCustomerSubscriptionCommand : IRequest<CustomerSubscriptionDto>
    {
        public CustomerSubscriptionDto CustomerRechargeDto { get; }
        
        public NewCustomerSubscriptionCommand(CustomerSubscriptionDto customerRechargeDto)
        {
            CustomerRechargeDto = customerRechargeDto;
        }
    }
}
