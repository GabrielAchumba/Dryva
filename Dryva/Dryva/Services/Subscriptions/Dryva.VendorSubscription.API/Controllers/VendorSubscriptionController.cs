using Dryva.VendorSubscription.API.Application.Commands;
using Dryva.VendorSubscription.API.Application.Queries;
using Dryva.VendorSubscription.API.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dryva.VendorSubscription.API.Controllers
{
    [Route("api/vendors/{vendorId:guid}")]
    [ApiController]
    public class VendorSubscriptionController : ControllerBase
    {
        private readonly IMediator mediator;

        public VendorSubscriptionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendorSubscriptionDto>>> GetVendorSubscriptionsById(Guid vendorId) {
            var query = new GetVendorSubscriptionsByIdQuery(vendorId);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<VendorSubscriptionDto>> NewSubscription(Guid vendorId, NewVendorSubscriptionDto vendorSubscriptionDto)
        {
            var command = new NewVendorSubscriptionCommand(vendorId, vendorSubscriptionDto);
            return await mediator.Send(command);
        }

        [HttpPatch]
        public async Task<ActionResult<VendorSubscriptionDto>> UpdateVendorSubscription(Guid vendorId, VendorSubscriptionDto vendorSubscriptionDto)
        {
            var command = new UpdateVendorSubscriptionCommand(vendorId, vendorSubscriptionDto);
            return await mediator.Send(command);
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteVendorSubscription(Guid vendorId)
        {
            var command = new DeleteVendorSubscriptionCommand(vendorId);
            return await mediator.Send(command);
        }
    }
}