using Application.Common.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationContext _context;
        private Lazy<IDepartmentRepository> _departmentRepository;
        private Lazy<IEmployeePositionRepository> _employeePositionRepository;
        private Lazy<IEmployeeRepository> _employeeRepository;


        public RepositoryManager(ApplicationContext context)
        {
            _departmentRepository = new Lazy<IDepartmentRepository>(() => new DepartmentRepository(context));
            _employeePositionRepository = new Lazy<IEmployeePositionRepository>(() => new EmployeePositionRepository(context));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(context));
            _context = context;
        }
        public IDepartmentRepository DepartmentRepository 
            => _departmentRepository.Value;

        public IEmployeePositionRepository EmployeePositionRepository 
            => _employeePositionRepository.Value;

        public IEmployeeRepository EmployeeRepository 
            => _employeeRepository.Value;

        public async Task SaveAsync(CancellationToken cancellationToken = default)
            => await _context.SaveChangesAsync(cancellationToken);
    }
}
