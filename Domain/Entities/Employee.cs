using Domain.Common;

namespace Domain.Entities
{
    public class Employee : EntityBase
    {
        private Employee() { } // for ef core 
        public NameDetails Name { get; set; }
        public EmployeePosition Position { get; set; }
        public int? PositionId { get; set; }
        public double BaseSalry { get; set; } = 0.0;
        public bool IsConsulttant { get; set; } = false;
        public Employee Supervisor { get; set; }
        public int? SupervisorId { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public DateTimeOffset Birthdate { get; set; }
        public Identifier Identifier { get; set; }
        public int IdentifierId { get; set; }
        public Address Address { get; set; }
        public Nationality Nationality { get; set; }
        public int NationalityId { get; set; }
    }
}
