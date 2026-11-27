namespace AFO.Application.Features.ServiceContents.Responses
{
    public class ServiceContentResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid ServiceId { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public List<string> Includes { get; set; } = [];
    }
}
