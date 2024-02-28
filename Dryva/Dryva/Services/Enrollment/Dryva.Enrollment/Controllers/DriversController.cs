using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dryva.Enrollment.Application.Handlers;
using Dryva.Enrollment.Application.Queries;
using Dryva.Enrollment.DTOs.Driver;
using Dryva.Enrollment.Repositories.Commands;
using Dryva.Enrollment.Repositories.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dryva.Enrollment.Controllers
{
    /// <summary>
    /// Represents the Drivers controller class.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="DriversController"/> class.
        /// </summary>
        /// <param name="queryRepository">The query repository.</param>
        public DriversController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;DriverDetailDTO&gt;&gt;.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriverDetailDTO>>> Get()
        {
            var query = new GetDriverDetailQuery();
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;DriverDataDTO&gt;.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<DriverDataDTO>> Get(Guid id)
        {
            var query = new GetDriverByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Gets the Driver by phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>Task&lt;DriverDTO&gt;.</returns>
        [HttpGet]
        [Route("DriverByPhoneNumber/{phoneNumber}")]
        public async Task<ActionResult<DriverDataDTO>> GetByPhoneNumber(string phoneNumber)
        {
            var query = new GetDriverByPhoneNumberQuery(phoneNumber);
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Gets the Driver by plate number.
        /// </summary>
        /// <param name="phoneNumber">The plate number.</param>
        /// <returns>Task&lt;DriverRegistrationDTO&gt;.</returns>
        [HttpGet]
        [Route("DriverByPlateNumber/{plateNumber}")]
        public async Task<ActionResult<DriverRegistrationDTO>> GetByPlateNumber(string plateNumber)
        {
            var query = new GetDriverByPlateNumberQuery(plateNumber);
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Gets the Driver registration by phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>Task&lt;DriverRegistrationDTO&gt;.</returns>
        [HttpGet]
        [Route("RegistrationByPhoneNumber/{phoneNumber}")]
        public async Task<ActionResult<DriverRegistrationDTO>> GetRegistrationByPhoneNumber(string phoneNumber)
        {
            var query = new GetDriverRegistrationByPhoneNumberQuery(phoneNumber);
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
        public async Task<ActionResult<DriverRegistrationDTO>> Post([FromBody] NewDriverRegistrationDTO value)
        {
            var command = new InsertDriverRegistrationDataCommand(value);
            var result = await _mediator.Send(command);

            if (result == null) return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Updates the registration.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        [HttpPut]
        [Route("Registration/{id}")]
        public async Task<ActionResult<DriverRegistrationDTO>> UpdateRegistration(Guid id, [FromBody] NewDriverRegistrationDTO value)
        {
            if (value == null)
                throw new NullReferenceException("Model can not be null");

            var command = new UpdateDriverRegistrationDataCommand(value, id);
            var result = await _mediator.Send(command);

            if (result == null) return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Updates the contact.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        [HttpPut]
        [Route("Contact/{id}")]
        public async Task<ActionResult<DriverContactDTO>> UpdateContact(Guid id, [FromBody] NewDriverContactDTO value)
        {
            if (value == null)
                throw new NullReferenceException("Model can not be null");

            var command = new UpdateDriverContactCommand(value, id);
            var result = await _mediator.Send(command);

            if (result == null) return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Updates the personal.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        [HttpPut]
        [Route("PersonalData/{id}")]
        public async Task<ActionResult<DriverPersonalDataDTO>> UpdatePersonalData(Guid id, [FromBody] DriverPersonalDataDTO value)
        {
            if (value == null)
                throw new NullReferenceException("Model can not be null");

            var command = new UpdateDriverPersonalDataCommand(value, id);
            var result = await _mediator.Send(command);

            if (result == null) return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Updates the bio data.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        [HttpPut]
        [Route("BioData/{id}")]
        public async Task<ActionResult<DriverBioDataDTO>> UpdateBioData(Guid id, [FromBody] DriverBioDataDTO value)
        {
            if (value == null)
                throw new NullReferenceException("Model can not be null");

            var command = new UpdateDriverBioDataCommand(value, id);
            var result = await _mediator.Send(command);

            if (result == null) return NotFound();

            return Ok(result);
        }


        /// <summary>
        /// Updates the owner nok data.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        [HttpPut]
        [Route("OwnerNOKData/{id}")]
        public async Task<ActionResult<DriverOwnerNOKDTO>> UpdateOwnerNOKData(Guid id, [FromBody] DriverOwnerNOKDTO value)
        {
            if (value == null)
                throw new NullReferenceException("Model can not be null");

            var command = new UpdateDriverOwnerNOKCommand(value, id);
            var result = await _mediator.Send(command);

            if (result == null) return NotFound();

            return Ok(result);
        }


        /// <summary>
        /// Updates the vehicle data.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        [HttpPut]
        [Route("VehicleData/{id}")]
        public async Task<ActionResult<DriverVehicleDTO>> UpdateVehicleData(Guid id, [FromBody] DriverVehicleDTO value)
        {
            if (value == null)
                throw new NullReferenceException("Model can not be null");

            var command = new UpdateDriverVehicleCommand(value, id);
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
            var command = new DeleteDriverCommand(id);
            var result = await _mediator.Send(command);

            if (result < 1) return NotFound();

            return Ok(result);
        }
    }
}
