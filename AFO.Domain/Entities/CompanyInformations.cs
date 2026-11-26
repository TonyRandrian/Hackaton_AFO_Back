namespace AFO.Domain.Entities
{
    public class CompanyInformations
    {
        public required string Infos { get; set; }
        public required string Value { get; set; }

        private CompanyInformations() { }
    }
}