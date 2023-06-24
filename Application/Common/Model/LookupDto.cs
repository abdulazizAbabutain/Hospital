using Application.Common.Mapping;
using AutoMapper;
using Domain.Common;

namespace Application.Common.Model
{
    public class LookupDto : IMapForm<EntityStatus>
    {
        public int Id { get; set; }
        public string NameArabic { get; set; }
        public string NameEnglish { get; set; }
    }
}
