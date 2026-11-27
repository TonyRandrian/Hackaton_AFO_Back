
namespace AFO.Application.Features.RealizationImages.Responses
{
    public class RealizationImageResponse
    {
        public Guid Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public Guid RealizationId { get; set; }
        public Guid RealizationImageTypeId { get; set; }
        public string TypeName { get; set; } = string.Empty;
    }
}
