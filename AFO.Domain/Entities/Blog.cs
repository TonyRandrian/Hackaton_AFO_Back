namespace AFO.Domain.Entities
{
    public class Blog
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Subtitle { get; set; }
        public DateTime PublishDate { get; set; }
        public Guid ServiceId { get; set; }
        public Service Service { get; set; } = null!;
        public string? Image { get; set; }
    }
}
