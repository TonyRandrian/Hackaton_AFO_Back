namespace AFO.Domain.Entities
{
    public class ServiceContent
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public Guid ServiceId { get; set; }
        public Service Service { get; set; } = null!;
        public ICollection<Pricing> Pricings { get; set; } = [];
        public ICollection<Realization> Realizations { get; set; } = [];

        private ServiceContent() { }
    }
}
