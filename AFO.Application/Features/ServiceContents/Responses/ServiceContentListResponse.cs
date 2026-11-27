namespace AFO.Application.Features.ServiceContents.Responses
{
    public class ServiceContentListResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public List<string> Includes { get; set; } = [];
    }
}
