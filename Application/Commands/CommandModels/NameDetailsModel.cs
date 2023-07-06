using Application.Common.Mapping;
using Domain.Entities;

namespace Application.Commands.CommandModels
{
    public class NameDetailsModel : IMapForm<NameDetails>
    {
        public string FirstNameArabic { get; set; } 
        public string? SecondNameArabic { get; set; }  
        public string? ThirdNameArabic { get; set; }
        public string LastNameArabic { get; set; }
        public string FirstNameEnglish { get; set; }
        public string? SecondNameEnglish { get; set; }
        public string? ThirdNameEnglish { get; set; }
        public string LastNameEnglish { get; set; }
    }
}
