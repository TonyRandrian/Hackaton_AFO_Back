
using AFO.Application.Interfaces;
using MediatR;
namespace AFO.Application.Features.Realizations.Commands.UpdateRealization;

public class UpdateRealizationCommandHandler( IRealizationRepository repository)
    : IRequestHandler<UpdateRealizationCommand, bool>
{
    public async Task<bool> Handle(UpdateRealizationCommand request,CancellationToken cancellationToken)
    {
        var realization = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (realization is null)
            return false;

        bool validRelation = await repository.VerifyServiceContentToServiceAsync( request.ServiceId,
                request.ServiceContentId,cancellationToken);

        if (!validRelation)
        {
            throw new ArgumentException( "Le contenu selectionné n'appartient pas à ce service ");
        }

        realization.Update(
            request.Name,
            request.ShortDescription,
            request.Title,
            request.SubTitle,
            request.ProjectUrl,
            request.AboutDescription,
            request.ProjectDescription,
            request.GoalDescription,
            request.Qualities,
            request.IsPublic
        );

        realization.ChangeService( request.ServiceId, request.ServiceContentId );
        await repository.UpdateAsync( realization,cancellationToken);
        return true;
    }
}
