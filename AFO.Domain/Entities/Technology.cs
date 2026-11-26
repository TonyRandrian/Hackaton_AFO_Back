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
        public Technology() { }
    }
}
