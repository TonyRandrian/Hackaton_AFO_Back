namespace AFO.Domain.Entities
{
    public  class RealizationImageType
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = "";
        public ICollection<RealizationImage> RealizationImages { get; private set; } = [];
        private RealizationImageType() { }

    }
}
