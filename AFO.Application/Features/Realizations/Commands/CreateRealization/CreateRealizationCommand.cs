using MediatR;
namespace AFO.Application.Features.Realizations.Commands.CreateRealization;

public record CreateRealizationCommand(
    string Name,
    string ShortDescription,
    string Title,
    string SubTitle,
    string ProjectUrl,
    string AboutDescription,
    string ProjectDescription,
    string GoalDescription,
    List<string> Qualities,
    bool IsPublic,
    Guid ServiceId,
    Guid ServiceContentId
) : IRequest<Guid>;
