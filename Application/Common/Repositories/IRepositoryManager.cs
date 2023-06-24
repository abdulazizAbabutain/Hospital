using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Repositories
{
    public interface IRepositoryManager
    {
        IDepartmentRepository DepartmentRepository { get; }
        IEmployeePositionRepository EmployeePositionRepository { get; }
        Task SaveAsync(CancellationToken cancellationToken); 
    }
}
