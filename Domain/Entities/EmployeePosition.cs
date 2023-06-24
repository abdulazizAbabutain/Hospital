using Domain.Common;

namespace Domain.Entities
{
    public class EmployeePosition : EntityBase
    {
        private EmployeePosition() { } // for EF core 
        private EmployeePosition(string nameArabic, string nameEnglish)
        {
            Name = ShortName.Create(nameArabic, nameEnglish);
        }
        public ShortName Name { get; private set; }
 
        public static EmployeePosition Create(string nameArabic, string nameEnglish)
            => new(nameArabic, nameEnglish);
    }
}
