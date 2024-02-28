using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dryva.Enrollment.Application.Commands;
using Dryva.Enrollment.Application.Queries;
using Dryva.Enrollment.DTOs.Driver;
using Dryva.Enrollment.DTOs.Investor;
using Dryva.Enrollment.Repositories.Commands;
using Dryva.Enrollment.Repositories.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dryva.Enrollment.Controllers
{
    /// <summary>
    /// Represents the Shareholders controller class.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class ShareholdersController : ControllerBase
    {

        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="DriversController"/> class.
        /// </summary>
        /// <param name="commandRepository">The command repository.</param>
        /// <param name="queryRepository">The query repository.</param>
        public ShareholdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;InvestorDTO&gt;&gt;.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvestorDTO>>> Get()
        {
            var query = new GetShareholdersQuery();
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;InvestorDTO&gt;.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<InvestorDTO>> Get(Guid id)
        {
            var query = new GetShareholdersByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Posts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        [HttpPost]
        public async Task<ActionResult<InvestorDTO>> Post([FromBody] NewInvestorDTO value)
        {
            var command = new InsertShareholdersCommand(value);
            var result = await _mediator.Send(command);

            if (result == null) return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<InvestorDTO>> Put(Guid id, [FromBody] NewInvestorDTO value)
        {
            if (value == null)
                throw new NullReferenceException("Model can not be null");

            var command = new UpdateShareholdersCommand(value, id);
            var result = await _mediator.Send(command);

            if (result == null) return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(Guid id)
        {
            var command = new DeleteShareholdersCommand(id);
            var result = await _mediator.Send(command);

            if (result < 1) return NotFound();

            return Ok(result);
        }
    }
}
