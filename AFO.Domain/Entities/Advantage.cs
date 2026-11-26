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
    }
}
