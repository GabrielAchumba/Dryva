using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dryva.Devices.Application.Commands;
using Dryva.Devices.Application.Queries;
using Dryva.Devices.Constants;
using Dryva.Devices.DTOs;
using Dryva.Devices.Repositories.Commands;
using Dryva.Devices.Repositories.Queries;
using Dryva.RabbitMQ;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dryva.Devices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRabbitManager _rabbitmanager;
        public RoutesController(
            IMediator mediator,
            IRabbitManager rabbitmanager)
        {
            _mediator = mediator;
            _rabbitmanager = rabbitmanager;
        }

        // GET: api/Routes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RouteDTO>>> Get()
        {
            var query = new GetRouteQuery();
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // GET: api/Routes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RouteDTO>> Get(Guid id)
        {
            var query = new GetRouteByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }


        // POST: api/Routes
        [HttpPost]
        public async Task<ActionResult<RouteDTO>> Post([FromBody] NewRouteDTO value)
        {
            var command = new InsertRouteCommand(value);
            var result = await _mediator.Send(command);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // PUT: api/Routes/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RouteDTO>> Put(Guid id, [FromBody] NewRouteDTO value)
        {
            var command = new UpdateRouteCommand(value, id);
            var result = await _mediator.Send(command);

            if (result == null) return NotFound();

            _rabbitmanager.Publish<RouteDTO>(result, RouteConstant.Device_Route_Queue, RouteConstant.Device_Route_Queue, RouteConstant.Device_Route_Update, null);

            return Ok(result);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(Guid id)
        {
            var command = new DeleteRouteCommand(id);
            var result = await _mediator.Send(command);

            if (result < 1) return NotFound();

            return Ok(result);
        }
    }
}
