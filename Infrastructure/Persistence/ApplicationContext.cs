using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base(options) 
        {

        }
        public DbSet<Department> Department => Set<Department>();
        public DbSet<EntityStatus> EntityStatus => Set<EntityStatus>();
        public DbSet<EmployeePosition> EmployeePosition => Set<EmployeePosition>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entity in ChangeTracker.Entries<EntityBase>())
            {
                switch(entity.State)
                {
                    case EntityState.Added:
                        entity.Entity.Created();
                        break;
                    case EntityState.Modified:
                        entity.Entity.Modifyed();
                        break;
                    case EntityState.Deleted:
                        entity.Entity.Deleted();
                        entity.State = EntityState.Modified;
                        break;
                }
            }
            
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
