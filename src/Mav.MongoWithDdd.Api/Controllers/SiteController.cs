using Asp.Versioning;
using Mav.MongoWithDdd.Application;
using Mav.MongoWithDdd.Application.Commands.Sites;
using Mav.MongoWithDdd.Application.Queries.Sites;
using Microsoft.AspNetCore.Mvc;

namespace Mav.MongoWithDdd.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SiteController(IRequestExecutor executor) : ControllerBase
    {
        private readonly IRequestExecutor _executor = executor;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var site = await _executor.ExecuteQuery(new GetSiteByIdQuery(id));
            return Ok(site);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sites = await _executor.ExecuteQuery(new GetAllSitesQuery());
            return Ok(sites);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSiteCommand command)
        {
            var id = await _executor.ExecuteCommand(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateSiteCommand command, CancellationToken cancellationToken)
        {
            await _executor.ExecuteCommand(command, cancellationToken);
            return NoContent();
        }
    }
}
