using InternPortal.Shared.Contracts.Internship.Responses;
using InternPortal.Shared.Contracts.Internship.Requests;
using InternPortal.Application.Abstractions.Services;
using InternPortal.Infrastructure.Mappers;
using InternPortal.Domain.Pagination;
using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using InternPortal.Domain.Sort;


namespace InternPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class InternshipController(IInternshipService internshipService) : Controller
    {
        [HttpGet]
        public async Task<ActionResult<PagedInternshipResponse>> GetAll([FromQuery] BaseFilter filter, [FromQuery] SortParams sort, [FromQuery] PageParams pageParams) 
        {
            var internships = await internshipService.GetAllInternships(filter, sort, pageParams);
            //плохо
            var internshipsCount = (await internshipService.GetAllInternships(filter, sort, null)).Count;

            var p = new PagedInternshipResponse(internshipsCount, internships.Select(Mapping.Mapper.Map<InternshipResponse>).ToList());
            return Ok(p);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<InternshipResponse>> GetById(Guid id)
            => Ok(Mapping.Mapper.Map<InternshipResponse>(await internshipService.GetInternshipById(id)));

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> Update(Guid id, [FromBody] InternshipRequest request)
            => Ok(await internshipService.UpdateInternship(id, Mapping.Mapper.Map<Internship>(request)));

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] InternshipRequest request)
            => Ok(await internshipService.CreateInternship(Mapping.Mapper.Map<Internship>(request)));

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteById(Guid id)
        {
            await internshipService.DeleteInternship(id);
            return Ok(id);
        }
    }
}
