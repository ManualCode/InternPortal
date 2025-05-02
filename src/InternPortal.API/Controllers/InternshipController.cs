using InternPortal.Shared.Contracts.Internship.Responses;
using InternPortal.Shared.Contracts.Internship.Requests;
using InternPortal.Application.Abstractions.Services;
using InternPortal.Domain.Pagination;
using InternPortal.Domain.Filters;
using Microsoft.AspNetCore.Mvc;
using InternPortal.Domain.Sort;


namespace InternPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class InternshipController(IInternshipService internshipService) : Controller
    {
        [HttpGet]
        public async Task<ActionResult<PagedInternshipResponse>> GetAll([FromQuery] BaseFilter filter,
            [FromQuery] SortParams sort, [FromQuery] PageParams pageParams) 
            => Ok(await internshipService.GetAllInternships(filter, sort, pageParams));

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<InternshipResponse>> GetById(Guid id)
            => Ok(await internshipService.GetInternshipById(id));

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> Update(Guid id, [FromBody] InternshipRequest request)
            => Ok(await internshipService.UpdateInternship(id, request));

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] InternshipRequest request)
            => Ok(await internshipService.CreateInternship(request));

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteById(Guid id)
        {
            await internshipService.DeleteInternship(id);
            return Ok(id);
        }
    }
}
