using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dryva.Enrollment.Application.Commands;
using Dryva.Enrollment.Application.Queries;
using Dryva.Enrollment.DTOs.CaptureSession;
using Dryva.Enrollment.Repositories.Commands;
using Dryva.Enrollment.Repositories.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dryva.Enrollment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaptureSessionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CaptureSessionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/CaptureSessions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaptureSessionDTO>>> Get()
        {
            var query = new GetCaptureSessionQuery();
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // GET: api/CaptureSessions/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<CaptureSessionDTO>> Get(Guid id)
        {
            var query = new GetCaptureSessionByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // POST: api/CaptureSessions
        [HttpPost]
        public async Task<ActionResult<CaptureSessionDTO>> Post([FromBody] NewCaptureSessionDTO value)
        {
            var command = new InsertCaptureSessionCommand(value);
            var result = await _mediator.Send(command);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // PUT: api/CaptureSessions/5
        [HttpPut]
        [Route("UpdatePhotograph/{id}")]
        public async Task<ActionResult<UpdatePhotographSessionDTO>> Put(Guid id, [FromBody] NewUpdatePhotographSessionDTO value)
        {
            if (value == null)
                throw new NullReferenceException("Model can not be null");

            var command = new UpdatePhotographSessionCommand(value, id);
            var result = await _mediator.Send(command);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // PUT: api/CaptureSessions/5
        [HttpPut]
        [Route("UpdateFingerprints/{id}")]
        public async Task<ActionResult<UpdateFingerprintsSessionDTO>> Put(Guid id, [FromBody] NewUpdateFingerprintsSessionDTO value)
        {
            if (value == null)
                throw new NullReferenceException("Model can not be null");

            var command = new UpdateFingerprintsSessionCommand(value, id);
            var result = await _mediator.Send(command);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(Guid id)
        {
            var command = new DeleteCaptureSessionCommand(id);
            var result = await _mediator.Send(command);

            if (result < 1) return NotFound();

            return Ok(result);
        }
    }
}
