using Application.Common.Repositories;
using Application.Queries.CommonModle;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.Departments.AddDepartment
{
    public class AddDepartmentCommandHandler : IRequestHandler<AddDepartmentCommand, QueryModel>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public AddDepartmentCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<QueryModel> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
        {
            var newDep = request.Name; 
            var department = Department.Create(newDep.NameArabic, newDep.NameEnglish);
            department.Name.SetDescriptions(newDep.DescriptionArabic, newDep.DescriptionEnglish);

            await _repositoryManager.DepartmentRepository.AddAsync(department, cancellationToken);
            await _repositoryManager.SaveAsync(cancellationToken);

            var depToReturen = _mapper.Map<QueryModel>(department);
            return depToReturen;
        }
    }
}
