namespace AFO.Domain.Entities
{
    public class ServiceProcessus
    {
        public Guid ServiceId { get; set; }
        public Guid ProcessusId { get; set; }
        public Service Service { get; set; } = null!;
        public Processus Processus { get; set; } = null!;
    }
}
