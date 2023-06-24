using Application.Common.Mapping;
using Application.Common.Model;
using Application.Common.Repositories;
using Application.Queries.Departments.CommonDto;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

namespace Application.Queries.Departments.GetDepartmentList
{
    public class GetDepartmentListQuery : 
        IRequest<(PaginatedList<DepartmentDto> list, MetaData metaData)>
    {
        /// <summary  xml:lang="En">
        /// Send the Page Number the defult size is 1.
        /// </summary>
        /// <summary xml:lang="Ar">
        ///  ارسال رقم الصفحة المطلوبة,اذا لم يتم اسناد قيمة ستكون قيمتها الإفتراضية 1
        /// </summary>
        public int PageNumber { get; set; } = 1;
        /// <summary  xml:lang="En">
        /// send an number of item in one page, the defult size is 10,
        /// </summary>
        /// <summary  xml:lang="Ar">
        /// ارسا حجم البيانات المطلوبة
        /// </summary>
        public int PageSize { get; set; } = 10; 
    }

    public class GetDepartmentListQueryHandler : IRequestHandler<GetDepartmentListQuery, (PaginatedList<DepartmentDto> list, MetaData metaData)>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetDepartmentListQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<(PaginatedList<DepartmentDto> list, MetaData metaData)> Handle(GetDepartmentListQuery request, CancellationToken cancellationToken)
        {
           var result = await _repositoryManager.DepartmentRepository
                .Get(trackChanges: false)
                .ProjectTo<DepartmentDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
            return (result, result.MetaData); 
        }
    }
}
