using AFO.Application.Features.FAQs.Responses;
using AFO.Application.Features.Realizations.Responses;

namespace AFO.Application.Features.Services.Responses
{
    public class ServiceResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string? ShortDescription { get; set; }
        public string? Image { get; set; }
        public string? Subtitle { get; set; }
        public string? ServiceDescription { get; set; }
        public string? ExpertiseDescription { get; set; }
        public string? RealizationDescription { get; set; }
        public List<RealizationListResponse> Realizations { get; set; } = [];
        public List<FAQListResponse> FAQs { get; set; } = [];
    }
}
