using System;
using System.Collections.Generic;
using System.Text;

namespace AFO.Domain.Entities
{
    public class RealizationProcessus
    {
        public Realization Realization { get; private set; } = null!;
        public Processus Processus { get; private set; } = null!;
        public RealizationProcessus() { }
    }
}
