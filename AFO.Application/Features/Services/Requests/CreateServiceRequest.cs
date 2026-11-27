namespace AFO.Application.Features.Services.Requests
{
    public class CreateServiceRequest
    {
        public required string Name { get; set; }
        public required string Title { get; set; }
        public string? ShortDescription { get; set; }
        public string? Image { get; set; }
        public string? Subtitle { get; set; }
        public string? ServiceDescription { get; set; }
        public string? ExpertiseDescription { get; set; }
        public string? RealizationDescription { get; set; }
    }
}
