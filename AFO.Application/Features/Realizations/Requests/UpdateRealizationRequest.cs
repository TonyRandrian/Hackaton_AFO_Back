
namespace AFO.Application.Features.Realizations.Requests;

public class UpdateRealizationRequest
{
    public string Name { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string SubTitle { get; set; } = string.Empty;
    public string ProjectUrl { get; set; } = string.Empty;
    public string AboutDescription { get; set; } = string.Empty;
    public string ProjectDescription { get; set; } = string.Empty;
    public string GoalDescription { get; set; } = string.Empty;
    public List<string> Qualities { get; set; } = [];
    public bool IsPublic { get; set; }
    public Guid ServiceId { get; set; }
    public Guid ServiceContentId { get; set; }
}
