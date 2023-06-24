using Application.Common.Model;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Departments.FullyUpdateDepartment
{
    public class FullyUpdateDepartmentCommand : IRequest
    {
        /// <summary>
        /// رقم المعرف للقسم
        /// </summary>
        public int Id { get; set; }
        public EntityNameDto Name { get; set; }
    }
}
