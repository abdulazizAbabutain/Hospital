using Domain.Common;
using Infrastructure.Persistence.DbConstants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class EntityStatusConfiguration : IEntityMap<EntityStatus>
    {
        public void Configure(EntityTypeBuilder<EntityStatus> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(build => build.NameArabic)
                .IsRequired()
                .HasMaxLength(ApplicationContextConst.MAX_LENGTH_NAME);
            
            builder.Property(build => build.NameEnglish)
                .IsRequired()
                .HasMaxLength(ApplicationContextConst.MAX_LENGTH_NAME);

            builder.HasData(new List<EntityStatus> 
            {
                new EntityStatus 
                {
                    Id = 1,
                    NameArabic = "فعال",
                    NameEnglish = "Active"
                },
                new EntityStatus
                {
                    Id = 2,
                    NameArabic = "معطل",
                    NameEnglish = "Deactivate"
                },
                  new EntityStatus
                {
                    Id = 3,
                    NameArabic = "محذوف",
                    NameEnglish = "Deleted"
                }
            });
        }
    }
}
