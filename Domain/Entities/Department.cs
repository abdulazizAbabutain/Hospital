using Domain.Common;

namespace Domain.Entities
{
    public class Department : EntityBase
    {
        private Department() { } // for EF core 
        private Department(string nameArabic, string nameEnglish)
        {
            Name = ShortName.Create(nameArabic, nameEnglish);
        }
        public ShortName Name { get; private set; }
        public static Department Create(string nameArabic, string nameEnglish) 
            => new(nameArabic, nameEnglish);
        

        public void SetStatus(bool isActive)
        {
            if(isActive)
                Activate();
            else
                Deactivate();
        }
    }
}
