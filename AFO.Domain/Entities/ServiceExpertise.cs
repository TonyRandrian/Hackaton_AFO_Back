namespace AFO.Domain.Entities
{
    public class ServiceExpertise
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public List<string> Contents { get; set; } = [];
        public Guid ServiceId { get; set; }
        public Service Service { get; set; } = null!;


        private ServiceExpertise() { }
    }
}
