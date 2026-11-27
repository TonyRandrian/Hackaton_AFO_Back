namespace AFO.Application.Features.FAQs.Responses
{
    public class FAQResponse
    {
        public Guid Id { get; set; }
        public Guid ServiceId { get; set; }
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
    }
}