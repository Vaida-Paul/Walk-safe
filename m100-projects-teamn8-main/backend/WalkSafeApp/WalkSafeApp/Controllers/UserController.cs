using MediatR;
using Microsoft.AspNetCore.Mvc;
using WalkSafe.Application.Commands.User;
using WalkSafe.Application.Querries.User;

namespace WalkSafe.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers()
        {
            var command = new GetAllUsersQuery();
            var result = await _mediator.Send(command);
            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var command = new GetUserByIdQuerry(id);
            var result = await _mediator.Send(command);
            if (result != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("register")]
        public async Task<IActionResult> AddUser(RegisterAccountCommand user)
        {
            var command = new RegisterAccountCommand(user.Email, user.Name, user.Password);
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(new {Token = result.Value});
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var command = new DeleteUserCommand(id);
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
