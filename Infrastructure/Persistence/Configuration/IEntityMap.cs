using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configuration
{
    public interface IEntityMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class
    {
    }
}
