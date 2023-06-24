using MediatR;
using System.Text.Json.Serialization;

namespace Application.Commands.Departments.UpdateStatusDepartment
{
    public class UpdateStatusDepartmentCommand : IRequest
    {
        /// <summary>
        /// the identity fire for 
        /// </summary>
        [JsonIgnore]
        public int Id { get; set; }
        /// <summary>
        /// send true tp change the status to true to be activae and false to be deactive.
        /// </summary>
        public bool IsActive { get; set; }
    }
}
