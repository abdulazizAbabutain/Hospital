using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Departments.DeleteDepartmet
{
    public class DeleteDepartmetCommand : IRequest
    {
        /// <summary>
        /// رقم المعرف للقسم
        /// </summary>
        public int Id { get; set; }
    }
}
