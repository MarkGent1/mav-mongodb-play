using Asp.Versioning;
using Mav.MongoWithDdd.Application;
using Mav.MongoWithDdd.Application.Commands.Customers;
using Mav.MongoWithDdd.Application.Queries.Customers;
using Microsoft.AspNetCore.Mvc;

namespace Mav.MongoWithDdd.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CustomerController(IRequestExecutor executor) : ControllerBase
    {
        private readonly IRequestExecutor _executor = executor;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var customer = await _executor.ExecuteQuery(new GetCustomerByIdQuery(id));
            return Ok(customer);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _executor.ExecuteQuery(new GetAllCustomersQuery());
            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCommand command)
        {
            var id = await _executor.ExecuteCommand(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            await _executor.ExecuteCommand(command, cancellationToken);
            return NoContent();
        }
    }
}
