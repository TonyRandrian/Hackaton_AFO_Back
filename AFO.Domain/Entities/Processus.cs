namespace AFO.Domain.Entities
{
    public class Processus
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Order { get; set; }
        public string LogoUrl { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public List<string> Contents = [];


        private Processus() { }
    }
}
