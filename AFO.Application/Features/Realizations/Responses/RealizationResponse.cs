
namespace AFO.Application.Features.Realizations.Responses;
public class RealizationResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string SubTitle { get; set; } = string.Empty;
    public bool IsPublic { get; set; }
    public string ProjectUrl { get; set; } = string.Empty;
    public string AboutDescription { get; set; } = string.Empty;
    public string ProjectDescription { get; set; } = string.Empty;
    public string GoalDescription { get; set; } = string.Empty;
    public List<string> Qualities { get; set; } = [];

    public Guid ServiceId { get; set; }
    public Guid ServiceContentId { get; set; }

    public List<RealizationImageResponse> Images { get; set; } = [];
    public List<RealizationAdvantageResponse> Advantages { get; set; } = [];
    public List<RealizationTechnologyResponse> Technologies { get; set; } = [];
    public List<RealizationProcessusResponse> Processus { get; set; } = [];
}

public class RealizationImageResponse
{
    public Guid Id { get; set; }
    public string Url { get; set; } = string.Empty;
    public Guid RealizationImageTypeId { get; set; }
    public string TypeName { get; set; } = string.Empty;
}

public class RealizationAdvantageResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class RealizationTechnologyResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LogoUrl { get; set; } = string.Empty;
}

public class RealizationProcessusResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Order { get; set; }
    public string? LogoUrl { get; set; }
    public string? Image { get; set; }
    public List<string> Contents { get; set; } = [];
}
