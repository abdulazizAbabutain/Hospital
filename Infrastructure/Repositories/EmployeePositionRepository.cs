using Application.Common.Repositories;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public sealed class EmployeePositionRepository : Repository<EmployeePosition>, IEmployeePositionRepository
    {
        public EmployeePositionRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
