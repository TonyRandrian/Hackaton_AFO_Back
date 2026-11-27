using System.ComponentModel.DataAnnotations;

namespace AFO.Application.Features.FAQs.Requests
{
    public class UpdateFAQRequest
    {
        public required string Question { get; set; }
        public required string Answer { get; set; }
    }
}