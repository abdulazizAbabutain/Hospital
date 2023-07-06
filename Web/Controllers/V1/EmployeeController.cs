using Application.Commands.Employees.AddEmployee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.V1
{

    public class EmployeeController : RootConstroler
    {
        public EmployeeController(IMediator mediator) 
            : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeComand comand)
        {
            await _mediator.Send(comand);
            return Ok();
        }
    }
}
