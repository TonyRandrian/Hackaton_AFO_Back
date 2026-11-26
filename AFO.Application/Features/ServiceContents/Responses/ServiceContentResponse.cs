namespace AFO.Application.Features.ServiceContents.Responses
{
    public class ServiceContentResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid ServiceId { get; set; }
    }
}
