namespace AFO.Domain.Entities
{
    public class Service
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? ShortDescription { get; set; }
        public string? Image { get; set; }
        public required string Title { get; set; }
        public string? Subtitle { get; set; }
        public string? ServiceDescription { get; set; }
        public string? ExpertiseDescription { get; set; }
        public string? RealizationDescription { get; set; }

        public ICollection<ServiceContent> Contents { get; set; } = [];
        public ICollection<ServiceExpertise> Expertises { get; set; } = [];
        public ICollection<FAQ> FAQs { get; set; } = [];
        public ICollection<ServiceProcessus> ServiceProcessus { get; set; } = [];
        public ICollection<Realization> Realizations { get; set; } = [];

        private Service() { }
    }
}
