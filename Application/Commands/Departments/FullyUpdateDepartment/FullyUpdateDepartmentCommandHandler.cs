using Application.Common.Exceptions;
using Application.Common.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.Departments.FullyUpdateDepartment
{
    public class FullyUpdateDepartmentCommandHandler : IRequestHandler<FullyUpdateDepartmentCommand>
    {
        private readonly IRepositoryManager _repositoryManager;

        public FullyUpdateDepartmentCommandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task Handle(FullyUpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _repositoryManager.DepartmentRepository.GetByCondetion(dep => dep.Id == request.Id, trackChanges: true).FirstOrDefaultAsync(cancellationToken);

            if (department == null)
                throw new NotFoundException(nameof(request.Id),request.Id);

            var updateDep = request.Name;
            
            department.Name.SetNames(updateDep.NameArabic, updateDep.NameEnglish);
            department.Name.SetDescriptions(updateDep.DescriptionArabic, updateDep.DescriptionEnglish);
            
            _repositoryManager.DepartmentRepository.Update(department);
            _repositoryManager.SaveAsync(cancellationToken);
        }
    }
}
