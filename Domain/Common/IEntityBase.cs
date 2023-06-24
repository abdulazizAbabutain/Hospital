using Domain.Enums;

namespace Domain.Common
{
    public interface IEntityBase 
    {
        public int Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get;  set; }
        public string? LastModifBy { get; set; }
        public DateTimeOffset LastModifyDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTimeOffset DeleteDate { get; set; }
        public string? DeactivatedBy { get; set; }
        public DateTimeOffset LastDeactivateDate { get; set; }
        public DateTimeOffset LastActivateeDate { get; set; }
        public EntityStatus Status { get; set; }
        public int StatusId { get; set; } 
    }
}