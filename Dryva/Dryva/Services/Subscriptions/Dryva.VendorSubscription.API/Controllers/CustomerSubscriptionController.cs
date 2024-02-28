using Dryva.VendorSubscription.API.Application.Commands;
using Dryva.VendorSubscription.API.Application.Queries;
using Dryva.VendorSubscription.API.Dtos;
using Dryva.VendorSubscription.API.ResourceParameters;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dryva.VendorSubscription.API.Controllers
{
    [Route("api/vendors/{vendorId:guid}/subscriptions")]
    [ApiController]
    public class CustomerSubscriptionController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomerSubscriptionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerSubscriptionDto>>> GetAllCustomerSubscriptionByVendorId(Guid vendorId)
        {
            var result = await mediator.Send(new GetAllCustomerSubscriptionsByVendorIdQuery(vendorId));
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerSubscriptionDto>> Subscribe([FromRoute]Guid vendorId, [FromBody]CustomerSubscriptionDto customerSubscriptionDto) {
            customerSubscriptionDto.VendorId = vendorId;
            var command = new NewCustomerSubscriptionCommand(customerSubscriptionDto);
            var result = await mediator.Send(command);
            return CreatedAtRoute("GetCustomerSubscriptionById", new { vendorId = result.VendorId, subscriptionId = result.SubscriptionId }, result);
        }

        [HttpPatch("{subscriptionid:guid}")]
        public async Task<ActionResult<CustomerSubscriptionDto>> UpdateCustomerSubscription(Guid subscriptionId, CustomerSubscriptionUpdateDto customerSubscriptionDto)
        {
            var command = new UpdateCustomerSubscriptionCommand(subscriptionId, customerSubscriptionDto);
            return await mediator.Send(command);
        }

        [HttpDelete("{subscriptionid:guid}")]
        public async Task<ActionResult<int>> DeleteRecord(Guid subscriptionId)
        {
            var command = new DeleteCustomerSubscriptionCommand(subscriptionId);
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{subscriptionid:guid}", Name = "GetCustomerSubscriptionById")]
        public async Task<ActionResult<CustomerSubscriptionDto>> GetCustomerSubcriptionById(Guid subscriptionId)
        {
            var result = await mediator.Send(new GetSubscriptionByIdQuery(subscriptionId));
            return Ok(result);
        }

        [HttpGet("dates")]
        public async Task<ActionResult<IEnumerable<CustomerSubscriptionDto>>> GetCustomerSubscriptionsByDateRange(DateRangeParameter dateRangeParameters)
        {
            var query = new GetCustomerSubscriptionsByDateRangeQuery(dateRangeParameters);
            var result = await mediator.Send(query);
            return Ok(result);
        }
                
    }
}