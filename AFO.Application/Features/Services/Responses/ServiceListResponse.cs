namespace AFO.Application.Features.Services.Responses
{
    public class ServiceListResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ShortDescription { get; set; }
        public string? Image { get; set; }
    }
}
