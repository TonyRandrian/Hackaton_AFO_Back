using System;
using System.Collections.Generic;
using System.Text;

namespace AFO.Domain.Entities
{
    public class Advantage
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = "";
        public string Description { get; private set; } = "";
        public ICollection<RealizationAdvantage> RealizationAdvantages { get; private set; } = [];
        public Advantage() { }
        public Advantage(string name, string? description)
        {
            Id = Guid.CreateVersion7();
            Update(name, description);
        }

        public void Update(string name, string? description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Le nom de l'avantage est obligatoire");
            Name = name.Trim();
            Description = description ?? string.Empty;
        }
    }
}
