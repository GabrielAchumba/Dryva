using CustomerSubscription.API.Application.Commands;
using CustomerSubscription.API.Application.Dtos;
using CustomerSubscription.API.Application.Queries;
using CustomerSubscription.API.ResourceParameters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CustomerSubscription.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{customerId:guid}/subscriptions/{subscriptionId:guid}", Name = "GetSubscriptionById")]
        public async Task<ActionResult<SubscriptionDto>> GetSubscriptionById(Guid subscriptionId)
        {
            var query = new GetSubscriptionByIdQuery(subscriptionId);
            var subscriptionDto = await _mediator.Send(query);

            if (subscriptionDto == null) {
                return NotFound();
            }

            return Ok(subscriptionDto);
        }

        [HttpGet("{customerId:guid}/subscriptions")]
        public async Task<ActionResult<IEnumerable<SubscriptionDto>>> GetSubscriptions(Guid customerId)
        {
            var query = new GetSubscriptionsQuery(new SubscriptionParameters { CustomerId = customerId });
            var result = await _mediator.Send(query);

            if (!result.Any()) return NotFound();
            return Ok(result);
        }

        [HttpGet("{cardSerialNumber:long}/subscriptions")]
        public async Task<ActionResult<IEnumerable<SubscriptionDto>>> GetSubscriptions(long cardSerialNumber)
        {
            var query = new GetSubscriptionsQuery(new SubscriptionParameters { CardSerialNumber = cardSerialNumber });
            var result = await _mediator.Send(query);
            
            if (!result.Any()) return NotFound();

            return Ok(result);
        }

        [HttpPost("subscribe")]
        public async Task<ActionResult> Subscribe(NewSubscriptionDto newSubscriptionDto)
        {
            var command = new NewSubscriptionCommand(newSubscriptionDto);
            var result = await _mediator.Send(command);
            return CreatedAtRoute(nameof(GetSubscriptionById), new { customerId = result.CustomerId, 
                subscriptionId = result.SubscriptionId }, result);
        }

        [HttpPut("{cardSerialNumber:long}/in")]
        public async Task<ActionResult<SubscriptionDto>> ClockIn(long cardSerialNumber)
        {
            var command = new ClockinCommand(cardSerialNumber);
            var subscriptionDto = await _mediator.Send(command);

            if (subscriptionDto == null) return NotFound();

            return Ok(subscriptionDto);
        }

        [HttpGet("{cardSerialNumber:long}/subscriptions/active", Name = "GetLatestSubscription")]
        public async Task<ActionResult<SubscriptionDto>> GetActiveSubscription(long cardSerialNumber)
        {
            var query = new GetActiveSubscriptionByCardSerialNumberQuery(cardSerialNumber);
            var subscriptionDto = await _mediator.Send(query);

            if (subscriptionDto == null) return NotFound();

            return Ok(subscriptionDto);
        }
        
        [HttpGet("{customerId:guid}/trips")]
        public async Task<ActionResult<SubscriberTripsDetailDto>> GetTripsInfo(Guid customerId) {
            var query = new GetTripsInfoByCustomerId(customerId);
            var result = await _mediator.Send(query);
            
            if (result == null) {
                return NotFound();
            }
            return Ok(result);
        }

        // this is not expected to be called by a customer app. strictly for internal processing/administrative functions.
        [HttpGet("subscribers")]
        public async Task<ActionResult<IEnumerable<SubscriberDto>>> GetSubscribersAsync()
        {
            var query = new GetSubscribersQueryAsync();
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }

    }
}