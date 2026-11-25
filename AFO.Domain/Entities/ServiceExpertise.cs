namespace AFO.Domain.Entities
{
    public class ServiceExpertise
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> Contents = [];
        public Service Service { get; set; }


        private ServiceExpertise() { }
    }
}
