using Application.Common.Model;
using MediatR;

namespace Application.Commands.EmployeePositions.AddEmployeePosition
{
    public class AddEmployeePositionCommand : IRequest
    {
        public EntityNameDto Name { get; set; }
    }
}
