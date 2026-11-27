
using AFO.Application.Features.Advantages.Responses;
using MediatR;

namespace AFO.Application.Features.Advantages.Queries.GetAdvantages;

public record GetAdvantagesQuery: IRequest<List<AdvantageListResponse>>;
