using Domain.Common;

namespace Domain.Entities
{
    public class Identifier : EntityBase
    {
        public int Id { get; set; }
        public IdentifierType IdentifierType { get; set; }
        public int IdentifierTypeId { get; set; }
        public string Number { get; set; }
        public DateTimeOffset IssueDateGregorian { get; set; }
        public DateTimeOffset ExpiryDateGregorian { get; set; }
        public string IssueDateUmAlQura { get; set; }
        public string ExpiryDateUmAlQura { get; set; }
    }
}