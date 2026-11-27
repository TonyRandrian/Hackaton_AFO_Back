namespace AFO.Application.Features.Services.Responses
{
    public class ServiceResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string? ShortDescription { get; set; }
        public string? Image { get; set; }
        public string? Subtitle { get; set; }
        public string? ServiceDescription { get; set; }
        public string? ExpertiseDescription { get; set; }
        public string? RealizationDescription { get; set; }
    }
}
