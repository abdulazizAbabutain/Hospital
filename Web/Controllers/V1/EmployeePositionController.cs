using Application.Commands.EmployeePositions.AddEmployeePosition;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeePositionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeePositionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployeePosition(AddEmployeePositionCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
