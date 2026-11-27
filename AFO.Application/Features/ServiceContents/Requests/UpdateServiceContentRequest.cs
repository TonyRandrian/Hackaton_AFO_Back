namespace AFO.Application.Features.ServiceContents.Requests
{
    public class UpdateServiceContentRequest
    {
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public string? Description { get; set; }
        public List<string> Includes { get; set; } = [];
    }
}
