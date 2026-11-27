
using AFO.Application.Features.Realizations.Responses;
using MediatR;
namespace AFO.Application.Features.Realizations.Queries.GetRealizations;

public record GetRealizationsQuery(bool PublicOnly = false): IRequest<List<RealizationListResponse>>;
