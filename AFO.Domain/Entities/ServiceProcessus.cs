namespace AFO.Domain.Entities
{
    public class ServiceProcessus
    {
        public Guid ServiceId { get; set; }
        public Service Service { get; set; } = null!;
        public Guid ProcessusId { get; set; }
        public Processus Processus { get; set; } = null!;
    }
}
