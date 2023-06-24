using Application.Common.Exceptions;
using Application.Common.Repositories;
using Application.Queries.Departments.CommonDto;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Departments.GetDepartment
{
    public class GetDepartmentQuery : IRequest<DepartmentDto>
    {
        public int Id { get; set; }
    }
    public class GetDepartmentQueryHandler : IRequestHandler<GetDepartmentQuery, DepartmentDto>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetDepartmentQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<DepartmentDto> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
        {
            var department  = await _repositoryManager.DepartmentRepository.GetByCondetion(dep => dep.Id == request.Id, trackChanges: false).ProjectTo<DepartmentDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync(cancellationToken);
            if (department is null)
                throw new NotFoundException(nameof(request.Id), request.Id);
            return department;
        }
    }
}
