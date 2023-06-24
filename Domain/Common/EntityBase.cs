using Domain.Enums;

namespace Domain.Common
{
    public class EntityBase : IEntityBase 
    {
        public int Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string? LastModifBy { get; set; }
        public DateTimeOffset LastModifyDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTimeOffset DeleteDate{ get; set; }
        public string? DeactivatedBy { get; set; }
        public DateTimeOffset LastDeactivateDate { get; set; }
        public DateTimeOffset LastActivateeDate { get; set; }
        public EntityStatus Status { get; set; }
        public int StatusId { get; set; } = (int)StatusEnum.Active;
        public void Created()
        {
            CreatedBy = "System"; 
            CreatedDate = DateTimeOffset.Now;
        }
        public void Modifyed()
        {
            LastModifBy = "System";
            LastModifyDate = DateTimeOffset.Now;
        }
        public void Deleted()
        {
            DeletedBy = "System";
            DeleteDate = DateTimeOffset.Now;
            StatusId = (int)StatusEnum.Deleted;
        }

        public void Activate()
        {
            LastActivateeDate = DateTimeOffset.Now;
            StatusId = (int)StatusEnum.Active;
        }
        public void Deactivate()
        {
            DeactivatedBy = "system";
            LastDeactivateDate = DateTimeOffset.Now;
            StatusId = (int)StatusEnum.Deactive;
        }
    }
}
