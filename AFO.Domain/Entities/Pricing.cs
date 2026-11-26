namespace AFO.Domain.Entities
{
    public class Pricing
    {
        public Guid Id { get; set; }
        public Guid ServiceContentId { get; set; }
        public ServiceContent ServiceContent { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public List<string> Includes { get; set; } = [];
    }
}
