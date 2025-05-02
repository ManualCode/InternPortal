using InternPortal.Shared.Contracts.Intern.Responses;
using InternPortal.Application.Abstractions.Services;
using InternPortal.Shared.Contracts.Intern.Requests;
using InternPortal.Infrastructure.Mappers;
using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace InternPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class InternController(IInternService internService) : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<InternResponse>>> GetAll([FromQuery] InternFilter filter)
            => Ok(await internService.GetAllInterns(filter));

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<InternResponse>> GetById(Guid id)
            => Ok(Mapping.Mapper.Map<InternResponse>(await internService.GetInternById(id)));

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] InternRequest request)
            => Ok(await internService.CreateIntern(request));

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> Update(Guid id, [FromBody] InternRequest request)
            => Ok(await internService.UpdateIntern(id, request));

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            await internService.DeleteIntern(id);
            return Ok(id);
        }

    }
}
