using Application.Common.Exceptions;
using Application.Common.Model;
using Application.Common.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Application.Queries.Departments.GetDepartmentStatus
{
    /// <summary xml:lang="Ar">
    /// ارسال طلب لإستعلام عن حالة القسم
    /// </summary>
    public class GetDepartmentStatusQuery : IRequest<LookupDto>
    {
        /// <summary xml:lang="Ar">
        /// العنوان المعرف للقسم
        /// </summary>
        [Required]
        public int Id { get; set; }
    }

    public class GetDepartmentStatusQueryHandler : IRequestHandler<GetDepartmentStatusQuery, LookupDto>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetDepartmentStatusQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<LookupDto> Handle(GetDepartmentStatusQuery request, CancellationToken cancellationToken)
        {
            var query = await _repositoryManager.DepartmentRepository
                .GetByCondetion(dep => dep.Id == request.Id, trackChanges: false)
                .Select(x => x.Status)
                .ProjectTo<LookupDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken);
            if (query == null)
                throw new NotFoundException(nameof(request.Id), request.Id);
            return query;
        }
    }
}
