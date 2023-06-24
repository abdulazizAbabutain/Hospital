using Application.Common.Exceptions;
using Application.Common.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Departments.UpdateStatusDepartment
{
    public class UpdateStatusDepartmentCommandHandler : IRequestHandler<UpdateStatusDepartmentCommand>
    {
        private readonly IRepositoryManager _repositoryManager;

        public UpdateStatusDepartmentCommandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task Handle(UpdateStatusDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _repositoryManager.DepartmentRepository.GetByCondetion(dep => dep.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

            if (department == null)
                throw new NotFoundException(nameof(request.Id), request.Id);
            department.SetStatus(request.IsActive);

            _repositoryManager.SaveAsync(cancellationToken);
        }
    }
}
