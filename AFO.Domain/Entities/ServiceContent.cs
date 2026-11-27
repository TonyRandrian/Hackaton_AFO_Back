using System.Diagnostics.CodeAnalysis;

namespace AFO.Domain.Entities
{
    public class ServiceContent
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public List<string> Includes { get; set; } = [];
        public Guid ServiceId { get; set; }
        public Service Service { get; set; } = null!;
        public ICollection<Realization> Realizations { get; set; } = [];


        private ServiceContent() { }

        [SetsRequiredMembers]
        public ServiceContent(string name, Guid serviceId, decimal price, string? description, List<string> includes)
        {
            Id = Guid.NewGuid();
            Name = name;
            ServiceId = serviceId;
            Price = price;
            Description = description;
            Includes = includes;
        }
    }
}
