
using AFO.Application.Interfaces;
using AFO.Domain.Entities;
using MediatR;
namespace AFO.Application.Features.Realizations.Commands.CreateRealization;

public class CreateRealizationCommandHandler(IRealizationRepository repository)
    : IRequestHandler<CreateRealizationCommand, Guid>
{
    public async Task<Guid> Handle(CreateRealizationCommand request,CancellationToken cancellationToken)
    {
        bool validRelation =await repository.VerifyServiceContentToServiceAsync(
                request.ServiceId,request.ServiceContentId,cancellationToken);

        if (!validRelation)
        {
            throw new ArgumentException("Le contenu selectionné n'appartient pas à ce service ");
        }

        Realization realization = new(
            request.Name,
            request.ShortDescription,
            request.Title,
            request.SubTitle,
            request.ProjectUrl,
            request.AboutDescription,
            request.ProjectDescription,
            request.GoalDescription,
            request.ServiceId,
            request.ServiceContentId,
            request.Qualities,
            request.IsPublic
        );
        await repository.AddAsync(realization, cancellationToken);
        return realization.Id;
    }
}
