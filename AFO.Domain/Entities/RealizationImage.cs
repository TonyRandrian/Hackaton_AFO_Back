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
        public RealizationImage(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("L'image de la realisation est obligatoire");
            Id = Guid.NewGuid();
            Url = url;
        }
    }                               
}
