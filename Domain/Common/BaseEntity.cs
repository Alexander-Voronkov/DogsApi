namespace Domain.Common
{
    public abstract class BaseEntity<PKeyType>
    {
        public PKeyType? Id { get; set; }
    }
}
