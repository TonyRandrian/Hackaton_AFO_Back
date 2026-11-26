namespace AFO.Domain.Entities
{
    public class ServiceProcessus
    {
        public int ServiceId { get; set; }
        public int ProcessusId { get; set; }
        public Service Service { get; set; } = null!;
        public Processus Processus { get; set; } = null!;
    }
}
