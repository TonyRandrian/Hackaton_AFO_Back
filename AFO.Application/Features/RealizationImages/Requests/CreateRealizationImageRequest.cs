
namespace AFO.Application.Features.RealizationImages.Requests
{
    public class CreateRealizationImageRequest
    {
        public required string Url { get; set; }
        public Guid RealizationImageTypeId { get; set; }
    }
}
