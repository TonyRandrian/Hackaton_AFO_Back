
using AFO.Application.Features.Advantages.Responses;
using MediatR;

namespace AFO.Application.Features.Advantages.Queries.GetAdvantageById;

public record GetAdvantageByIdQuery(Guid Id)  : IRequest<AdvantageResponse?>;
