namespace AFO.Domain.Entities
{
    public class Pricing
    {
        public Guid Id { get; set; }
        public int ServiceContentId { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public List<string> Includes { get; set; } = [];
        public ServiceContent ServiceContent { get; set; } = null!;
    }
}
