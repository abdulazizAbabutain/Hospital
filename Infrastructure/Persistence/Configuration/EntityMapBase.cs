using Domain.Common;
using Domain.Enums;
using Infrastructure.Persistence.DbConstants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    /// <summary>
    /// abstarct class the apply all the configuration for the entities
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class EntityMapBase<TEntity> : IEntityMap<TEntity> where TEntity : class, IEntityBase
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(build => build.Id)
                .ValueGeneratedOnAdd();

            builder.Property(build => build.CreatedBy)
                .HasMaxLength(ApplicationContextConst.MAX_LENGTH_NAME);

            builder.Property(build => build.LastModifBy)
                .HasMaxLength(ApplicationContextConst.MAX_LENGTH_NAME);

            builder.Property(build => build.DeletedBy)
                .HasMaxLength(ApplicationContextConst.MAX_LENGTH_NAME);

            builder.Property(build => build.DeactivatedBy)
                .HasMaxLength(ApplicationContextConst.MAX_LENGTH_NAME);

            builder.Property(build => build.StatusId)
                .HasDefaultValue(ApplicationContextConst.STATUS_CODE_ACTIVE);

            builder.HasQueryFilter(x => x.StatusId != (int)StatusEnum.Deleted);

            builder.HasOne(rel => rel.Status)
                .WithMany()
                .HasForeignKey(x => x.StatusId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
