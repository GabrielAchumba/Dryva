using Dryva.VendorSubscription.API.Dtos;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System;

namespace Dryva.VendorSubscription.API.Application.Commands
{
    public class UpdateCustomerSubscriptionCommand : IRequest<CustomerSubscriptionDto>
    {
        public CustomerSubscriptionUpdateDto CustomerSubscriptionUpdateDto { get; }

        public Guid SubscriptionId { get; }

        public UpdateCustomerSubscriptionCommand(Guid subscriptionId, CustomerSubscriptionUpdateDto customerSubscriptionUpdateDto)
        {
            SubscriptionId = subscriptionId;
            CustomerSubscriptionUpdateDto = customerSubscriptionUpdateDto;
        }
    }
}
