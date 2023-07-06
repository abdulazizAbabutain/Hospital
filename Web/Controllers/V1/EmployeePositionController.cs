using Application.Commands.EmployeePositions.AddEmployeePosition;
using Application.Queries.EmployeePostions.GetListEmployeePostion;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Common.Extenstions;

namespace Web.Controllers.V1
{
    public class EmployeePositionController : RootConstroler
    {
        public EmployeePositionController(IMediator mediator) 
            : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployeePosition(AddEmployeePositionCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployeePositionList([FromQuery]GetListEmployeePostionQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.Response.AddPagantionHeaders(result.metaData);
            return Ok(result.list);
        }
    }
}
