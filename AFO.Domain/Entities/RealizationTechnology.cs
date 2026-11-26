using System;
using System.Collections.Generic;
using System.Text;

namespace AFO.Domain.Entities
{
    public class RealizationTechnology
    {
        public Realization Realization { get; private set; } = null!;
        public Technology Technology { get; private set; } = null!;
        public RealizationTechnology() { }
    }
}
