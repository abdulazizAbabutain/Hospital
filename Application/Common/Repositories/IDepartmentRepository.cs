using Domain.Entities;

namespace Application.Common.Repositories
{
    public interface IDepartmentRepository :  IRepository<Department>
    {
        Task<Department> GetDepartmentAsyn(int id,CancellationToken cancellationToken = default);
    }
}
