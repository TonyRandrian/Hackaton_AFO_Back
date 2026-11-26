namespace AFO.Domain.Entities
{
    public class RealizationProcessus
    {
        public Guid RealizationId { get; private set; }
        public Realization Realization { get; private set; } = null!;

        public Guid ProcessusId { get; private set; }
        public Processus Processus { get; private set; } = null!;

        private RealizationProcessus() { }
    }
}
