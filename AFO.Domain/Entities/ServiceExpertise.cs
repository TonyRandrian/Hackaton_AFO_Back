namespace AFO.Domain.Entities
{
    public class ServiceExpertise
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public List<string> Contents = [];
        public int ServiceId;
        public Service Service { get; set; }


        private ServiceExpertise() { }
    }
}
