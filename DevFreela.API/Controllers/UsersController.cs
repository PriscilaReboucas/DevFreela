using DevFreela.API.Extensions;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Commands.LoginUser;
using DevFreela.Application.Queries.GetUser;
using DevFreela.Application.Validators;
using DevFreela.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var query = new GetUserQuery(id);

            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // https://www.devfreela.com/api/users HTTP POST
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserInputModel inputModel)
        {
            var command = new CreateUserCommand(
                inputModel.Name, inputModel.Email,
                inputModel.BirthDate,
                inputModel.Password,
                inputModel.Role);

            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetUser), new { id = result.Id }, result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
