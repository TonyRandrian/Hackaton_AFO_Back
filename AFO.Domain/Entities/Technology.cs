using System;
using System.Collections.Generic;
using System.Text;

namespace AFO.Domain.Entities
{
    public class Technology
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = "";
        public string LogoUrl { get; private set; } = "";
        public ICollection<RealizationTechnology> RealizationTechnologies { get; private set; } = [];

        private Technology() { }
        public Technology(string name, string logoUrl)
        {
            Id = Guid.CreateVersion7();
            Update(name, logoUrl);
        }

        public void Update(string name, string logoUrl)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Le nom de la technologie est obligatoire ");

            if (string.IsNullOrWhiteSpace(logoUrl))
                throw new ArgumentException("L'URL du logo est obligatoire ");

            Name = name.Trim();
            LogoUrl = logoUrl.Trim();
        }
    }
}