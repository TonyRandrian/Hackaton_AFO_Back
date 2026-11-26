namespace AFO.Domain.Entities;

public class Realization
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string ShortDescription { get; private set; } = string.Empty;
    public string Title { get; private set; } = string.Empty;
    public string SubTitle { get; private set; } = string.Empty;
    public bool IsPublic { get; private set; }
    public string ProjectUrl { get; private set; } = string.Empty;
    public string AboutDescription { get; private set; } = string.Empty;
    public string ProjectDescription { get; private set; } = string.Empty;
    public string GoalDescription { get; private set; } = string.Empty;
    public List<string> Qualities { get; private set; } = [];

    // Relations vers la partie Service 
    public Guid ServiceId { get; private set; }
    public Service Service { get; private set; } = null!;
    public Guid ServiceContentId { get; private set; }
    public ServiceContent ServiceContent { get; private set; } = null!;

    // Relations de la partie Realization
    public ICollection<RealizationImage> Images { get; private set; } = [];
    public ICollection<RealizationAdvantage> RealizationAdvantages { get; private set; } = [];
    public ICollection<RealizationTechnology> RealizationTechnologies { get; private set; } = [];
    public ICollection<RealizationProcessus> RealizationProcessus { get; private set; } = [];

    private Realization() { }
    public Realization(string name,string? shortDescription, string title, string? subTitle, bool isPublic, string projectUrl, string? aboutDescription,string? projectDescription,string? goalDescription)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Le nom de la realisation est obligatoire");
        if(string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Le titre de la realisation est obligatoire");
        if (string.IsNullOrWhiteSpace(projectUrl))
            throw new ArgumentException("Le site vers ce projet de la realisation est obligatoire");
        Id = Guid.NewGuid();
        Name = name.Trim();
        ShortDescription = shortDescription;
        Title = title;
        SubTitle = subTitle;
        ProjectUrl = projectUrl;
        AboutDescription = aboutDescription;
        ProjectDescription = projectDescription;
        GoalDescription = goalDescription;
        IsPublic = true; 

    }
}