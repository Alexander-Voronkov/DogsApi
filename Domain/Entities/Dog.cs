using Domain.Common;

namespace Domain.Entities
{
    public class Dog : BaseEntity<int>, ISoftDeletable
    {
        public string? Name { get; set; }
        public string? Color { get; set; }
        public double? TailLength { get; set; }
        public double? Weight { get; set; }
        public bool IsDeleted { get; set; }
    }
}
