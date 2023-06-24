namespace Domain.Common
{
    public class EntityStatus
    {
        public int Id { get; set; }
        public string NameArabic { get; set; }
        public string NameEnglish { get; set; }

        public static EntityStatus New = new EntityStatus
        {
            Id = 1,
            NameArabic = "فعال",
            NameEnglish = "Active",
        };
    }
}