namespace AFO.Domain.Entities
{
    public class RealizationProcessus
    {
        public int RealizationId { get; set; }
        public Realization Realization { get; set; } = null!;
        public int ProcessusId { get; set; }
        public Processus Processus { get; set; } = null!;


        public RealizationProcessus() { }
    }
}
