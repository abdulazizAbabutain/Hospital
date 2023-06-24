using Domain.Entities;
using Infrastructure.Persistence.DbConstants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class DepartmentConfigration : EntityMapBase<Department>
    {
        public override void Configure(EntityTypeBuilder<Department> builder)
        {
            base.Configure(builder);

            builder.OwnsOne(x => x.Name); 

        }
    }
}
