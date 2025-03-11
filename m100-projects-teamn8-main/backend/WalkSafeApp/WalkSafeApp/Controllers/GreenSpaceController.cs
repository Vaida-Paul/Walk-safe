using MediatR;
using Microsoft.AspNetCore.Mvc;
using WalkSafe.Application.Commands.GreenSpace;
using WalkSafe.Application.Querries.GreenSpace;

namespace WalkSafeApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GreenSpaceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GreenSpaceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll() 
        {
            var command = new GetAllGSQuery();
            var result = await _mediator.Send(command);
            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var command = new GetGSByIdQuery(id);
            var result = await _mediator.Send(command);
            if(result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddGreenSpace(AddGreenSpaceCommand greenSpace)
        {
            var command = new AddGreenSpaceCommand(greenSpace.Name, greenSpace.Description, greenSpace.Longitude, greenSpace.Latitude);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveGreenSpace(Guid id)
        {
            var command = new RemoveGreenSpaceCommand(id);
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
