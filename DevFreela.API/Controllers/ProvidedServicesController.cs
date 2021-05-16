using DevFreela.Application.Commands.CreateMessage;
using DevFreela.Application.Commands.CreateProvidedService;
using DevFreela.Application.Commands.StartProvidedService;
using DevFreela.Application.Queries.GetProvidedService;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ProvidedServicesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProvidedServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Post([FromBody] CreateProvidedServiceCommand command) {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetProvidedServiceQuery(id);

            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("{id}/start")]
        [Authorize(Roles = "freelancer")]
        public async Task<IActionResult> Start(int id)
        {
            var command = new StartProvidedServiceCommand(id);

            await _mediator.Send(command);

            return NoContent(); 
        }

        [HttpPost("{id}/messages")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> PostMessage(int id, [FromBody] CreateMessageInputModel inputModel)
        {
            var command = new CreateMessageCommand(id, inputModel.Content);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
