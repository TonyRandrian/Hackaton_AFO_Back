namespace AFO.Domain.Entities
{
    public class FAQ
    {
        public Guid Id { get; set; }
        public required string Question { get; set; }
        public required string Answer { get; set; }
        public Guid ServiceId { get; set; }
        public Service Service { get; set; } = null!;
    }
}
