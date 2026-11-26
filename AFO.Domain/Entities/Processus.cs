namespace AFO.Domain.Entities
{
    public class Processus
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int Order { get; set; }
        public string? LogoUrl { get; set; }
        public string? Image { get; set; }
        public ICollection<string> Contents = [];
        public ICollection<ServiceProcessus> ServiceProcessus { get; set; } = [];
        public ICollection<>

        private Processus() { }
    }
}
