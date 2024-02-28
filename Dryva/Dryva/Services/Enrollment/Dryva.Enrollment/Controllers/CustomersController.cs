using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dryva.Enrollment.Application.Handlers;
using Dryva.Enrollment.Application.Queries;
using Dryva.Enrollment.DTOs.Customer;
using Dryva.Enrollment.Repositories.Commands;
using Dryva.Enrollment.Repositories.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dryva.Enrollment.Controllers
{
    /// <summary>
    /// Represents the Customers controller class.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersController"/> class.
        /// </summary>
        public CustomersController( IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Customers
        /// <summary>
        /// Gets the details of all customers available.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;CustomerDetailDTO&gt;&gt;.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDetailDTO>>> Get()
        {
            var query = new GetCustomerDetailQuery();
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // GET: api/Customers/5
        /// <summary>
        /// Gets the detail of the customer by id.
        /// </summary>
        /// <param name="id">The customer id.</param>
        /// <returns>Task&lt;CustomerDataDTO&gt;.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDataDTO>> Get(Guid id)
        {
            var query = new GetCustomerByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Gets the customer by phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>Task&lt;CustomerDTO&gt;.</returns>
        [HttpGet]
        [Route("CustomerByPhoneNumber/{phoneNumber}")]
        public async Task<ActionResult<CustomerDataDTO>> GetByPhoneNumber(string phoneNumber)
        {
            var query = new GetCustomerByPhoneNumberQuery(phoneNumber);
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }


        /// <summary>
        /// Gets the customer registration by phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>Task&lt;CustomerRegistrationDTO&gt;.</returns>
        [HttpGet]
        [Route("RegistrationByPhoneNumber/{phoneNumber}")]
        public async Task<ActionResult<CustomerRegistrationDTO>> GetRegistrationByPhoneNumber(string phoneNumber)
        {
            var query = new GetCustomerRegistrationByPhoneNumberQuery(phoneNumber);
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // POST: api/Customers
        /// <summary>
        /// Registers a new Customer.
        /// </summary>
        /// <param name="value">The customer registration DTO.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        [HttpPost]
        public async Task<ActionResult<CustomerRegistrationDTO>> Post([FromBody] NewCustomerRegistrationDTO value)
        {
            var command = new InsertCustomerRegistrationDataCommand(value);
            var result = await _mediator.Send(command);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // PUT: api/Customers/5
        /// <summary>
        /// Updates the customer registration details.
        /// </summary>
        /// <param name="id">The customer id.</param>
        /// <param name="value">The customer registration DTO.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        [HttpPut]
        [Route("Registration/{id}")]
        public async Task<ActionResult<CustomerRegistrationDTO>> UpdateRegistration(Guid id, [FromBody] NewCustomerRegistrationDTO value)
        {
            if (value == null)
                throw new NullReferenceException("Model can not be null");

            var command = new UpdateCustomerRegistrationDataCommand(value, id);
            var result = await _mediator.Send(command);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // PUT: api/Customers/5
        /// <summary>
        /// Updates the customer contact detail.
        /// </summary>
        /// <param name="id">The customer id.</param>
        /// <param name="value">The customer contact DTO.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        [HttpPut]
        [Route("Contact/{id}")]
        public async Task<ActionResult<CustomerContactDTO>> UpdateContact(Guid id, [FromBody] NewCustomerContactDTO value)
        {
            if (value == null)
                throw new NullReferenceException("Model can not be null");

            var command = new UpdateCustomerContactCommand(value, id);
            var result = await _mediator.Send(command);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // PUT: api/Customers/5
        /// <summary>
        /// Updates the customer personal data details.
        /// </summary>
        /// <param name="id">The customer id.</param>
        /// <param name="value">The customer personal data DTO.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        [HttpPut]
        [Route("PersonalData/{id}")]
        public async Task<ActionResult<CustomerPersonalDataDTO>> UpdatePersonalData(Guid id, [FromBody] NewCustomerPersonalDataDTO value)
        {
            if (value == null)
                throw new NullReferenceException("Model can not be null");

            var command = new UpdateCustomerPersonalDataCommand(value, id);
            var result = await _mediator.Send(command);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // PUT: api/Customers/5
        /// <summary>
        /// Updates the customer bio data details.
        /// </summary>
        /// <param name="id">The customer id.</param>
        /// <param name="value">The customer bio data DTO.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        [HttpPut]
        [Route("BioData/{id}")]
        public async Task<ActionResult<CustomerBioDataDTO>> UpdateBioData(Guid id, [FromBody] NewCustomerBioDataDTO value)
        {
            if (value == null)
                throw new NullReferenceException("Model can not be null");

            var command = new UpdateCustomerBioDataCommand(value, id);
            var result = await _mediator.Send(command);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // PUT: api/Customers/5
        /// <summary>
        /// Updates the customer CSN details.
        /// </summary>
        /// <param name="id">The customer id.</param>
        /// <param name="value">The customer CSN DTO.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        [HttpPut]
        [Route("CSN/{id}")]
        public async Task<ActionResult<CustomerCSNDTO>> UpdateCSN(Guid id, [FromBody] NewCustomerCSNDTO value)
        {
            if (value == null)
                throw new NullReferenceException("Model can not be null");

            var command = new UpdateCustomerCSNCommand(value, id);
            var result = await _mediator.Send(command);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // DELETE: api/ApiWithActions/5
        /// <summary>
        /// Deletes the customer by id.
        /// </summary>
        /// <param name="id">The customer id.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(Guid id)
        {
            var command = new DeleteCustomerCommand(id);
            var result = await _mediator.Send(command);

            if (result < 1) return NotFound();

            return Ok(result);
        }
    }
}
