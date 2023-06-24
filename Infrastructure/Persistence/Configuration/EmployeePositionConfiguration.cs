using Domain.Entities;
using Infrastructure.Persistence.DbConstants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class EmployeePositionConfiguration : EntityMapBase<EmployeePosition>
    {
        public override void Configure(EntityTypeBuilder<EmployeePosition> builder)
        {
            base.Configure(builder);

            builder.OwnsOne(x => x.Name);

        }
    }
}
