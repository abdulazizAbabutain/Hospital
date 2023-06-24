using Application.Common.Exceptions;
using Application.Common.Repositories;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public sealed class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationContext context) 
            : base(context)
        {
      
        }

        public async Task<Department> GetDepartmentAsyn(int id,CancellationToken cancellationToken = default)
        {
            var department = await GetByCondetion(dep => dep.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
            if (department == null)
                throw new NotFoundException(nameof(id), id);
            return department;
        }
    }
}
