using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dryva.Enrollment.Application.Queries;
using Dryva.Enrollment.DTOs.Investor;
using Dryva.Enrollment.DTOs.Lga;
using Dryva.Enrollment.Repositories.Commands;
using Dryva.Enrollment.Repositories.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dryva.Enrollment.Controllers
{
    /// <summary>
    /// Class LGAsController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class LGAsController : ControllerBase
    {

        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="LGAsController"/> class.
        /// </summary>
        public LGAsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;LGADTO&gt;&gt;.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LGADTO>>> Get()
        {
            var query = new GetLGAQuery();
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;LGADTO&gt;.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<LGADTO>> Get(Guid id)
        {
            var query = new GetLGAByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Gets the lga by state identifier.
        /// </summary>
        /// <param name="stateId">The state identifier.</param>
        /// <returns>Task&lt;IEnumerable&lt;LGADTO&gt;&gt;.</returns>
        [HttpGet]
        [Route("StateId/{stateId}")]
        public async Task<ActionResult<IEnumerable<LGADTO>>> GetByStateId(Guid stateId)
        {
            var query = new GetLGAByStateIdQuery(stateId);
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Gets the lga by state name.
        /// </summary>
        /// <param name="stateName">The state name.</param>
        /// <returns>Task&lt;IEnumerable&lt;LGADTO&gt;&gt;.</returns>
        [HttpGet]
        [Route("StateName/{stateName}")]
        public async Task<ActionResult<IEnumerable<LGADTO>>> GetByStateName(string stateName)
        {
            var query = new GetLGAByStateNameQuery(stateName);
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }

    }
}
