
using AFO.Application.Features.Realizations.Responses;
using AFO.Application.Interfaces;
using MediatR;
namespace AFO.Application.Features.Realizations.Queries.GetRealizationById;

public class GetRealizationByIdQueryHandler(  IRealizationRepository repository)
    : IRequestHandler<GetRealizationByIdQuery, RealizationResponse?>
{
    public async Task<RealizationResponse?> Handle( GetRealizationByIdQuery request, CancellationToken cancellationToken)
    {
        var r = await repository.GetByIdAsync(  request.Id,  cancellationToken);

        if (r is null)
            return null;

        return new RealizationResponse
        {
            Id = r.Id,
            Name = r.Name,
            ShortDescription = r.ShortDescription,
            Title = r.Title,
            SubTitle = r.SubTitle,
            IsPublic = r.IsPublic,
            ProjectUrl = r.ProjectUrl,
            AboutDescription = r.AboutDescription,
            ProjectDescription = r.ProjectDescription,
            GoalDescription = r.GoalDescription,
            Qualities = r.Qualities,
            ServiceId = r.ServiceId,
            ServiceContentId = r.ServiceContentId,

            Images = r.Images.Select(i => new RealizationImageResponse
            {
                Id = i.Id,
                Url = i.Url,
                RealizationImageTypeId = i.RealizationImageTypeId,
                TypeName = i.RealizationImageType.Name
            }).ToList(),

            Advantages = r.RealizationAdvantages.Select(ra =>
                new RealizationAdvantageResponse
                {
                    Id = ra.Advantage.Id,
                    Name = ra.Advantage.Name,
                    Description = ra.Advantage.Description
                }).ToList(),

            Technologies = r.RealizationTechnologies.Select(rt =>
                new RealizationTechnologyResponse
                {
                    Id = rt.Technology.Id,
                    Name = rt.Technology.Name,
                    LogoUrl = rt.Technology.LogoUrl
                }).ToList(),

            Processus = r.RealizationProcessus
                .Select(rp => rp.Processus)
                .OrderBy(p => p.Order)
                .Select(p => new RealizationProcessusResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Order = p.Order,
                    LogoUrl = p.LogoUrl,
                    Image = p.Image,
                    Contents = p.Contents.ToList()
                }).ToList()
        };
    }
}
