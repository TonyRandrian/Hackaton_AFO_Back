namespace AFO.Domain.Entities
{
    public class FAQ
    {
        public int Id { get; set; }
        public required string Question { get; set; }
        public required string Answer { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;
    }
}
