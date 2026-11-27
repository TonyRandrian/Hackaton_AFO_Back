
using AFO.Application.Features.Realizations.Commands.CreateRealization;
using AFO.Application.Features.Realizations.Commands.UpdateRealization;
using AFO.Application.Features.Realizations.Commands.DeleteRealization;
using AFO.Application.Features.Realizations.Queries.GetRealizations;
using AFO.Application.Features.Realizations.Queries.GetRealizationById;
using AFO.Application.Features.Realizations.Requests;
using AFO.Application.Features.Realizations.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AFO.API.Controllers;

[ApiController]
[Route("api/realizations")]
public class RealizationsController(ISender sender) : ControllerBase
{
    // GET: api/realizations
    // GET: api/realizations?publicOnly=true
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] bool publicOnly = false)
    {
        List<RealizationListResponse> realizations = await sender.Send(new GetRealizationsQuery(publicOnly));

        return Ok(realizations);
    }

    // GET: api/realizations/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        RealizationResponse? realization =  await sender.Send(new GetRealizationByIdQuery(id));

        if (realization is null)
            return NotFound();

        return Ok(realization);
    }

    // POST: api/realizations
    [HttpPost]
    public async Task<IActionResult> Create( [FromBody] CreateRealizationRequest request)
    {
        CreateRealizationCommand command = new( request.Name,
            request.ShortDescription,
            request.Title,
            request.SubTitle,
            request.ProjectUrl,
            request.AboutDescription,
            request.ProjectDescription,
            request.GoalDescription,
            request.Qualities,
            request.IsPublic,
            request.ServiceId,
            request.ServiceContentId );

        Guid id = await sender.Send(command);

        return CreatedAtAction( nameof(GetById), new { id }, new { id } );
    }

    // PUT: api/realizations/{id}
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update( Guid id, [FromBody] UpdateRealizationRequest request)
    {
        UpdateRealizationCommand command = new( id,
            request.Name,
            request.ShortDescription,
            request.Title,
            request.SubTitle,
            request.ProjectUrl,
            request.AboutDescription,
            request.ProjectDescription,
            request.GoalDescription,
            request.Qualities,
            request.IsPublic,
            request.ServiceId,
            request.ServiceContentId
        );

        bool found = await sender.Send(command);

        if (!found)
            return NotFound();

        return NoContent();
    }

    // DELETE: api/realizations/{id}
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        bool found = await sender.Send(new DeleteRealizationCommand(id));

        if (!found)
            return NotFound();

        return NoContent();
    }
}
