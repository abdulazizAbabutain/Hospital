using Application.Common.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationContext _context;
        private Lazy<IDepartmentRepository> _departmentRepository;
        private Lazy<IEmployeePositionRepository> _employeePositionRepository;


        public RepositoryManager(ApplicationContext context)
        {
            _departmentRepository = new Lazy<IDepartmentRepository>(() => new DepartmentRepository(context));
            _employeePositionRepository = new Lazy<IEmployeePositionRepository>(() => new EmployeePositionRepository(context));
            _context = context;
        }
        public IDepartmentRepository DepartmentRepository => _departmentRepository.Value;

        public IEmployeePositionRepository EmployeePositionRepository => _employeePositionRepository.Value;

        public async Task SaveAsync(CancellationToken cancellationToken = default)
            => await _context.SaveChangesAsync(cancellationToken);
    }
}
