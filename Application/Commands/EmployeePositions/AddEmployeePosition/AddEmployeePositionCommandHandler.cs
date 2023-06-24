using Application.Common.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Commands.EmployeePositions.AddEmployeePosition
{
    public class AddEmployeePositionCommandHandler : IRequestHandler<AddEmployeePositionCommand>
    {
        private readonly IRepositoryManager _repositoryManager;

        public AddEmployeePositionCommandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task Handle(AddEmployeePositionCommand request, CancellationToken cancellationToken)
        {
            var req = request.Name;
            var newEmployeePosition = EmployeePosition.Create(req.NameArabic, req.NameEnglish);
            newEmployeePosition.Name.SetDescriptions(req.DescriptionArabic, req.DescriptionEnglish);
            await _repositoryManager.EmployeePositionRepository.AddAsync(newEmployeePosition, cancellationToken);
            _repositoryManager.SaveAsync(cancellationToken);

        }
    }
}
