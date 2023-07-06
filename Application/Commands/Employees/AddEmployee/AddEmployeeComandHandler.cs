using Application.Common.Exceptions;
using Application.Common.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Commands.Employees.AddEmployee
{
    public class AddEmployeeComandHandler : IRequestHandler<AddEmployeeComand>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public AddEmployeeComandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task Handle(AddEmployeeComand request, CancellationToken cancellationToken)
        {
            var mapedEmployeeRequet = _mapper.Map<Domain.Entities.Employee>(request);
            if (!await _repositoryManager.DepartmentRepository.IsExistsAync(dep => dep.Id == request.DepartmentId))
                throw new NotFoundException(nameof(request.DepartmentId), request.DepartmentId);
            if (!await _repositoryManager.EmployeePositionRepository.IsExistsAync(empos => empos.Id == request.PositionId))
                throw new NotFoundException(nameof(request.PositionId), request.PositionId);
            if (request.SupervisorId.HasValue && !await _repositoryManager.EmployeeRepository.IsExistsAync(emp => emp.Id == request.SupervisorId))
                throw new NotFoundException(nameof(request.SupervisorId), request.SupervisorId);

            await _repositoryManager.EmployeeRepository.AddAsync(mapedEmployeeRequet);
            await _repositoryManager.SaveAsync(cancellationToken);
        }
    }
}
