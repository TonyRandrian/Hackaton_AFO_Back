namespace AFO.Domain.Entities
{
    public class Service
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public string ServiceDescription { get; set; } = string.Empty;
        public string ExpertiseDescription { get; set; } = string.Empty;
        public string RealizationDescription { get; set; } = string.Empty;


        private Service() { }
    }
}
