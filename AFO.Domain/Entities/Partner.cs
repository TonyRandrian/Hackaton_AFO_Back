namespace AFO.Domain.Entities
{
    public class Partner
    {
        public Guid Id { get; private set; }
        public required string Name { get; set; }
        public string? LogoUrl { get; set; }

        private Partner() { }

    }
}
