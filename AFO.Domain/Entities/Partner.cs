using System;
using System.Collections.Generic;
using System.Text;

namespace AFO.Domain.Entities
{
    internal class Partner
    {
        public Guid Id { get; private set; }
        public string Name { get;private set; } = "";
        public string Logo { get; set; }

        private Partner() { }

    }
}
