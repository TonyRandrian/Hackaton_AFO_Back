namespace AFO.Domain.Entities
{
    public class RealizationProcessus
    {
<<<<<<< HEAD
        public Guid RealizationId { get; private set; }
        public Realization Realization { get; private set; } = null!;

        public Guid ProcessusId { get; private set; }
        public Processus Processus { get; private set; } = null!;

        private RealizationProcessus() { }
=======
        public int RealizationId { get; set; }
        public Realization Realization { get; set; } = null!;
        public int ProcessusId { get; set; }
        public Processus Processus { get; set; } = null!;


        public RealizationProcessus() { }
>>>>>>> 350466c41ea4b7d3a7ab6272a21e901de2e7e746
    }
}
