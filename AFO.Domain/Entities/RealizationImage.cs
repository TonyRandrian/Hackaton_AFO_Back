using System;
using System.Collections.Generic;
using System.Text;

namespace AFO.Domain.Entities
{
    public  class RealizationImage
    {
        public Guid Id { get; private set; }
        public string Url { get; private set; } = "";

        public Guid RealizationId { get; private set; }
        public Realization Realization { get; private set; } = null!;

        public Guid RealizationImageTypeId { get; private set; }
        public RealizationImageType RealizationImageType { get; private set; } = null!;

        private RealizationImage() { }

        public RealizationImage(string url, Guid realizationId,Guid realizationImageTypeId)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("L'URL de l'image est obligatoire");

            if (realizationId == Guid.Empty)
                throw new ArgumentException("La realisation est obligatoire");

            if (realizationImageTypeId == Guid.Empty)
                throw new ArgumentException("Le type d'image est obligatoire ");

            Id = Guid.NewGuid();
            Url = url.Trim();
            RealizationId = realizationId;
            RealizationImageTypeId = realizationImageTypeId;
        }

        public void Update(string url,Guid realizationImageTypeId)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("L'URL de l'image est obligatoire ");

            if (realizationImageTypeId == Guid.Empty)
                throw new ArgumentException("Le type d'image est obligatoire ");

            Url = url.Trim();
            RealizationImageTypeId = realizationImageTypeId;
        }
    }                               
}
