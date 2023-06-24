using Application.Common.Mapping;
using Domain.Entities;

namespace Application.Common.Model
{
    public class EntityNameDto : IMapForm<ShortName>
    {
        /// <summary>
        /// الإسم بالعربية
        /// </summary>
        public string NameArabic { get; set; }
        /// <summary>
        /// الإسم بالنجليزية
        /// </summary>
        public string NameEnglish { get; set; }
        /// <summary>
        /// الوصف باللغة العربية
        /// </summary>
        public string? DescriptionArabic { get; set; }
        /// <summary>
        /// الوصف باللغة الإنجليزية
        /// </summary>
        public string? DescriptionEnglish { get; set; }

    }
}
