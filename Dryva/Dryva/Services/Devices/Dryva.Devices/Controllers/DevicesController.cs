using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dryva.Devices.Application.Commands;
using Dryva.Devices.Application.Queries;
using Dryva.Devices.DTOs;
using Dryva.Devices.Repositories.Commands;
using Dryva.Devices.Repositories.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dryva.Devices.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DevicesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/Devices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetailsDTO>>> Get()            
        {
            var query = new GetDeviceQuery();
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // GET: api/Devices/routeId
        [HttpGet("route/{routeId}", Name = "GetByRoute")]
        //[HttpGet]
        //[Route("route/{routeId}")]
        public async Task<ActionResult<IEnumerable<DetailsDTO>>> GetByRoute(Guid routeId)
        {
            var query = new GetDeviceByRouteIdQuery(routeId);
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // GET: api/Devices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetailsDTO>> Get(Guid id)
        {
            var query = new GetDeviceByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("GetByTerminal/{terminal}")]
        public async Task<ActionResult<DetailsDTO>> GetByTerminal(int terminal)
        {
            var query = new GetDeviceByTerminalQuery(terminal);
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("GetDeviceTrails/{terminal}")] 
        public async Task<ActionResult<IEnumerable<DeviceTrailDTO>>> GetDeviceTrails(int terminal)
        {
            var query = new GetDeviceTrailsByTerminalQuery(terminal);
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("GetTransitLogsByCsn/{csn}")]
        public async Task<ActionResult<IEnumerable<TransitLogDetailsDTO>>> GetTransitLogsByCsn(int csn)
        {
            var query = new GetDeviceTransitLogsByCSNQuery(csn);
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("GetTransitLogsByCsnAndTime/{csn}")]
        public async Task<ActionResult<IEnumerable<TransitLogDetailsDTO>>> GetTransitLogsByCsnAndTime(int csn,
            DateTime? from = null, DateTime? to = null)
        {
            var query = new GetDeviceTransitLogsByCsnAndTimeQuery(csn, from, to);
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // POST: api/Devices
        [HttpPost]
        public async Task<ActionResult<DeviceDTO>> Post([FromBody] NewDeviceDTO value)
        {
            var command = new InsertDeviceCommand(value);
            var result = await _mediator.Send(command);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // POST: api/Devices
        [HttpPost]
        [Route("PostDeviceTrail")]
        public async Task<ActionResult<DeviceTrailDTO>> PostDeviceTrail([FromBody] DeviceTrailDTO value)
        {
            var command = new InsertDeviceTrailCommand(value);
            var result = await _mediator.Send(command);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Route("PostEntryLog")]
        public async Task<ActionResult<EntryTransitLogDTO>> PostEntryLog([FromBody] EntryTransitLogDTO value)
        {
            var command = new InsertDeviceEntryLogCommand(value);
            var result = await _mediator.Send(command);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Route("PostExitLog")]
        public async Task<ActionResult<ExitTransitLogDTO>> PostExitLog([FromBody] ExitTransitLogDTO value)
        {
            var command = new InsertDeviceExitLogCommand(value);
            var result = await _mediator.Send(command);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // PUT: api/Devices/5
        [HttpPut("{id}")]
        public async Task<ActionResult<DeviceDTO>> Put(Guid id, [FromBody] NewDeviceDTO value)
        {
            var command = new UpdateDeviceCommand(value,id);
            var result = await _mediator.Send(command);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(Guid id)
        {
            var command = new DeleteDeviceCommand(id);
            var result = await _mediator.Send(command);

            if (result < 1) return NotFound();

            return Ok(result);
        }
    }
}
