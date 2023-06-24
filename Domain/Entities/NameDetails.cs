using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class NameDetails
    {
        [Required]
        [MaxLength(50)]
        [Column(nameof(FirstNameArabic))]
        public string FirstNameArabic { get; set; } = string.Empty;
        [MaxLength(50)]
        [Column(nameof(SecondNameArabic))]
        public string? SecondNameArabic { get; set; }
        [MaxLength(50)]
        [Column(nameof(ThirdNameArabic))]
        public string? ThirdNameArabic { get; set; }
        [Required]
        [MaxLength(50)]
        [Column(nameof(LastNameArabic))]
        public string LastNameArabic { get; set; }
        [Required]
        [MaxLength(50)]
        [Column(nameof(FirstNameEnglish))]
        public string FirstNameEnglish { get; set; }
        [MaxLength(50)]
        [Column(nameof(SecondNameEnglish))]
        public string? SecondNameEnglish { get; set; }
        [MaxLength(50)]
        [Column(nameof(ThirdNameEnglish))]
        public string? ThirdNameEnglish { get; set; }
        [Required]
        [MaxLength(50)]
        [Column(nameof(LastNameEnglish))]
        public string LastNameEnglish { get; set; }

        public string FullNameArabic => $"{FirstNameArabic} {SecondNameArabic} {ThirdNameArabic} {LastNameArabic}";
        public string FullNameEnglish => $"{FirstNameEnglish} {SecondNameEnglish} {ThirdNameEnglish} {LastNameEnglish}";

    }
}
