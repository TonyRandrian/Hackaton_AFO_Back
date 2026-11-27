
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

    public Guid ServiceId { get; private set; }
    public Service Service { get; private set; } = null!;

    public Guid ServiceContentId { get; private set; }
    public ServiceContent ServiceContent { get; private set; } = null!;

    public ICollection<RealizationImage> Images { get; private set; } = [];
    public ICollection<RealizationAdvantage> RealizationAdvantages { get; private set; } = [];
    public ICollection<RealizationTechnology> RealizationTechnologies { get; private set; } = [];
    public ICollection<RealizationProcessus> RealizationProcessus { get; private set; } = [];

    private Realization() { }

    public Realization(string name,string shortDescription,string title,string subTitle,string projectUrl,string aboutDescription,string projectDescription, string goalDescription,Guid serviceId,Guid serviceContentId,IEnumerable<string>? qualities,bool isPublic = false)
    {
        if (serviceId == Guid.Empty)
            throw new ArgumentException("Le service est obligatoire");

        if (serviceContentId == Guid.Empty)
            throw new ArgumentException("Le contenue du service est obligatoire ");

        Id = Guid.NewGuid();

        Update(name,shortDescription, title,  subTitle, projectUrl, aboutDescription, projectDescription,  goalDescription,  qualities, isPublic);

        ServiceId = serviceId;
        ServiceContentId = serviceContentId;
    }

    public void Update(string name, string shortDescription,string title, string subTitle,string projectUrl, string aboutDescription, string projectDescription, string goalDescription,IEnumerable<string>? qualities, bool isPublic)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Le nom est obligatoire");

        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Le titre est obligatoire");

        if (string.IsNullOrWhiteSpace(shortDescription))
            throw new ArgumentException("La description  est obligatoire");

        if (string.IsNullOrWhiteSpace(subTitle))
            throw new ArgumentException("Le sous titre est obligatoire");

        if (string.IsNullOrWhiteSpace(projectUrl))
            throw new ArgumentException("L'URL du projet est obligatoire ");

        Name = name.Trim();
        ShortDescription = shortDescription.Trim();
        Title = title.Trim();
        SubTitle = subTitle.Trim();
        ProjectUrl = projectUrl.Trim();

        AboutDescription = aboutDescription?.Trim() ?? string.Empty;
        ProjectDescription = projectDescription?.Trim() ?? string.Empty;
        GoalDescription = goalDescription?.Trim() ?? string.Empty;

        Qualities = qualities?
            .Where(q => !string.IsNullOrWhiteSpace(q))
            .Select(q => q.Trim())
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList() ?? [];

        IsPublic = isPublic;
    }

    // Modification du service associé
    public void ChangeService(Guid serviceId, Guid serviceContentId)
    {
        if (serviceId == Guid.Empty || serviceContentId == Guid.Empty)
            throw new ArgumentException("Le service et son contenu sont obligatoires ");

        ServiceId = serviceId;
        ServiceContentId = serviceContentId;
    }
}
