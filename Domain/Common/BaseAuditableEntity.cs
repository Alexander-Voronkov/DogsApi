namespace Domain.Common
{
    public abstract class BaseAuditableEntity<PKeyType> : BaseEntity<PKeyType>
    {
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset LastModifiedAt { get; set; }
    }
}
