
namespace AFO.Application.Features.RealizationImages.Requests
{
    public class UpdateRealizationImageRequest
    {
        public required string Url { get; set; }
        public Guid RealizationImageTypeId { get; set; }
    }
}
