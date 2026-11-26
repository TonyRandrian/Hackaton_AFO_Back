using System;
using System.Collections.Generic;
using System.Text;

namespace AFO.Domain.Entities
{
    public class RealizationAdvantage
    {
        public Guid Id { get; private set; }
        public Guid AdvantageId { get; private set; }
        public Advantage Advantage { get; private set; } = null!;
        public Guid RealizationId { get; private set; }
        public Realization Realization { get; private set; } = null!;
        private RealizationAdvantage() { }
    }
}
