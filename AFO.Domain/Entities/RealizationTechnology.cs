using System;
using System.Collections.Generic;
using System.Text;

namespace AFO.Domain.Entities
{
    public class RealizationTechnology
    {
        public Guid RealizationId { get; private set; }
        public Realization Realization { get; private set; } = null!;

        public Guid TechnologyId { get; private set; }
        public Technology Technology { get; private set; } = null!;
        private RealizationTechnology() { }
    }
}
