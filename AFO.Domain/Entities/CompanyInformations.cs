using System;
using System.Collections.Generic;
using System.Text;

namespace AFO.Domain.Entities
{
    internal class CompanyInformations
    {
        public string Infos { get; private set; } = "";
        public string Value { get;private set; } = "";

        private CompanyInformations() { }
    }
}
