
namespace AFO.Application.Features.RealizationImages.Responses
{
    public class RealizationImageListResponse
    {
        public Guid Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public Guid RealizationImageTypeId { get; set; }
        public string TypeName { get; set; } = string.Empty;
    }
}
