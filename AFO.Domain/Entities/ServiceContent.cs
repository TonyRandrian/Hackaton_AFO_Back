namespace AFO.Domain.Entities
{
    public class ServiceContent
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Service Service;


        private ServiceContent() { }
    }
}
