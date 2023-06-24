using Application.Common.Exceptions;
using Application.Common.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.Departments.DeleteDepartmet
{
    public class DeleteDepartmetCommandHandler : IRequestHandler<DeleteDepartmetCommand>
    {
        private readonly IRepositoryManager _repositoryManager;

        public DeleteDepartmetCommandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task Handle(DeleteDepartmetCommand request, CancellationToken cancellationToken)
        {
            var department = await _repositoryManager.DepartmentRepository.GetDepartmentAsyn(request.Id, cancellationToken);
            _repositoryManager.DepartmentRepository.Delete(department);
            _repositoryManager.SaveAsync(cancellationToken);
        }
    }
}
