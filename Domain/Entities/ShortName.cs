using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class ShortName 
    {
        [Required]
        [Column(nameof(NameArabic))]
        [MaxLength(50)]
        public string NameArabic { get; private set; } = string.Empty;
        [Required]
        [Column(nameof(NameEnglish))]
        [MaxLength(50)]
        public string NameEnglish { get; private set; } = string.Empty;
        [Column(nameof(DescriptionArabic))]
        [MaxLength(1500)]
        public string? DescriptionArabic { get; private set; }
        [Column(nameof(DescriptionEnglish))]
        [MaxLength(1500)]
        public string? DescriptionEnglish { get; private set; }
        private ShortName(string nameArabic, string nameEnglish)
        {
            NameArabic= nameArabic;
            NameEnglish= nameEnglish;
        }
        public static ShortName Create(string nameArabic, string nameEnglish)
            => new(nameArabic, nameEnglish);

        public void SetDescriptions(string? descriptionArabic, string? descriptionEnglish)
        {
            DescriptionArabic = descriptionArabic;
            DescriptionEnglish = descriptionEnglish;
        }
        public void SetNames(string nameArabic, string nameEnglish)
        {
            NameArabic = nameArabic;
            NameEnglish = nameEnglish;
        }
    }
}
