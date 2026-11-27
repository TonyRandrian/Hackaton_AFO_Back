
using AFO.Application.Features.Advantages.Commands.CreateAdvantage;
using AFO.Application.Features.Advantages.Commands.UpdateAdvantage;
using AFO.Application.Features.Advantages.Commands.DeleteAdvantage;
using AFO.Application.Features.Advantages.Queries.GetAdvantages;
using AFO.Application.Features.Advantages.Queries.GetAdvantageById;
using AFO.Application.Features.Advantages.Requests;
using AFO.Application.Features.Advantages.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AFO.API.Controllers;

[ApiController]
[Route("api/advantages")]
public class AdvantagesController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<AdvantageListResponse> advantages = await sender.Send(new GetAdvantagesQuery());

        return Ok(advantages);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        AdvantageResponse? advantage =
            await sender.Send(new GetAdvantageByIdQuery(id));

        if (advantage is null)
            return NotFound();

        return Ok(advantage);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAdvantageRequest request)
    {
        Guid? id = await sender.Send(
            new CreateAdvantageCommand(request.Name, request.Description));

        if (id is null)
            return BadRequest("Impossible de créer cet avantage ");

        return Created($"/api/advantages/{id}", id);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateAdvantageRequest request)
    {
        bool found = await sender.Send(
            new UpdateAdvantageCommand(id, request.Name, request.Description));

        if (!found)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        bool found = await sender.Send(new DeleteAdvantageCommand(id));

        if (!found)
            return NotFound();

        return NoContent();
    }
}
