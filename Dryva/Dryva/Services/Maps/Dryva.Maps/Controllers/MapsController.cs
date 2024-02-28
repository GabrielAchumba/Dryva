using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dryva.Maps.Application.Commands;
using Dryva.Maps.Application.Queries;
using Dryva.Maps.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dryva.Maps.Controllers
{
    /// <summary></summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase"/>
    [Route("api/[controller]")]
    [ApiController]
    public class MapsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MapsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets the specified page index.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IEnumerable&lt;MapAxisDTO&gt;&gt;.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MapAxisDTO>>> Get(int pageIndex = 1, int pageSize = 100)
        {
            var query = new GetMapQuery(pageIndex, pageSize);
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // GET: api/Maps/5
        /// <summary>Gets the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Map ais model</returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<MapAxisDTO>> Get(Guid id)
        {
            var query = new GetMapByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Gets the specified longitude.
        /// </summary>
        /// <param name="longitude">The longitude.</param>
        /// <param name="latitude">The latitude.</param>
        /// <returns>Task&lt;MapAxisDTO&gt;.</returns>
        [HttpGet("ClosestMapAxisByLocation/{longitude}/{latitude}")]
        public async Task<ActionResult<MapAxisDTO>> Get(float longitude, float latitude)
        {
            var query = new GetMapByLocationQuery(longitude, latitude);
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }
        // POST: api/Maps
        /// <summary>Posts the specified value.</summary>
        /// <param name="value">The value.</param>
        /// <returns>int</returns>
        [HttpPost]
        public async Task<ActionResult<MapAxisDTO>> Post([FromBody] NewMapAxisDTO value)
        {
            var command = new InsertMapCommand(value);
            var result = await _mediator.Send(command);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // PUT: api/Maps/5
        /// <summary>Puts the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns>int</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<MapAxisDTO>> Put(Guid id, [FromBody] NewMapAxisDTO value)
        {
            if (value == null)
                throw new NullReferenceException("Model can not be null");

            var command = new UpdateMapCommand(value, id);
            var result = await _mediator.Send(command);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // DELETE: api/Maps/5
        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>int</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(Guid id)
        {
            var command = new DeleteMapCommand(id);
            var result = await _mediator.Send(command);

            if (result < 1) return NotFound();

            return Ok(result);
        }
    }
}
