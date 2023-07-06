using Application.Commands.CommandModels;
using Application.Common.Mapping;
using Domain.Entities;
using MediatR;

namespace Application.Commands.Employees.AddEmployee
{
    public class AddEmployeeComand : IRequest, IMapForm<Employee>
    {
        public NameDetailsModel Name { get; set; }
        public int PositionId { get; set; }
        public double BaseSalry { get; set; }
        public bool IsConsulttant { get; set; }
        public int DepartmentId { get; set; }
        public int? SupervisorId { get; set; }
    }
}
