
namespace AFO.Application.Features.Realizations.Responses;
public class RealizationListResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public bool IsPublic { get; set; }
    public string ProjectUrl { get; set; } = string.Empty;
}
