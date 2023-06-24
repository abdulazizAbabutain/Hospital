//using Domain.Entities;
//using Infrastructure.Persistence.DbConstants;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Persistence.Configuration
//{
//    public class EmployeeConfigurtion : EntityMapBase<Employee>
//    {
//        public override void Configure(EntityTypeBuilder<Employee> builder)
//        {
//            builder.OwnsOne(own => own.Name);

//            builder.Property(build => build.DepartmentId)
//                .IsRequired();

//            builder.HasOne(rel => rel.Department)
//                .WithMany(rel => rel.Employees)
//                .HasForeignKey(FK => FK.DepartmentId);

//            builder.HasOne(rel => rel.Supervisor)
//                .WithMany()
//                .HasForeignKey(FK => FK.SupervisorId)
//                .OnDelete(DeleteBehavior.SetNull);

//            builder.HasOne(rel => rel.Position).WithMany()
//                .HasForeignKey(FK => FK.PositionId);

      
        

//            base.Configure(builder);
//        }
//    }
//}
