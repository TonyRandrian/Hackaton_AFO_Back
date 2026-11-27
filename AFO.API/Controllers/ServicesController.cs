using AFO.Application.Features.Services.Commands.CreateService;
using AFO.Application.Features.Services.Commands.DeleteService;
using AFO.Application.Features.Services.Commands.UpdateService;
using AFO.Application.Features.Services.Queries.GetServiceById;
using AFO.Application.Features.Services.Queries.GetServices;
using AFO.Application.Features.Services.Requests;
using AFO.Application.Features.Services.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AFO.API.Controllers
{
    [ApiController]
    [Route("api/services")]
    public class ServicesController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<ServiceListResponse> services = await sender.Send(new GetServicesQuery());
            return Ok(services);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            ServiceResponse? service = await sender.Send(new GetServiceByIdQuery(id));

            if (service is null)
                return NotFound();

            return Ok(service);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceRequest request)
        {
            CreateServiceCommand command = new()
            {
                Name = request.Name,
                Title = request.Title,
                ShortDescription = request.ShortDescription,
                Image = request.Image,
                Subtitle = request.Subtitle,
                ServiceDescription = request.ServiceDescription,
                ExpertiseDescription = request.ExpertiseDescription,
                RealizationDescription = request.RealizationDescription
            };

            Guid id = await sender.Send(command);

            return Created($"/api/services/{id}", id);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateServiceRequest request)
        {
            UpdateServiceCommand command = new()
            {
                Id = id,
                Name = request.Name,
                Title = request.Title,
                ShortDescription = request.ShortDescription,
                Image = request.Image,
                Subtitle = request.Subtitle,
                ServiceDescription = request.ServiceDescription,
                ExpertiseDescription = request.ExpertiseDescription,
                RealizationDescription = request.RealizationDescription
            };

            bool found = await sender.Send(command);

            if (!found)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool found = await sender.Send(new DeleteServiceCommand(id));

            if (!found)
                return NotFound();

            return NoContent();
        }
    }
}
