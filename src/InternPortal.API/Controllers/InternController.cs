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
    public class InternController(IInternService internService,
        IProjectSevice projectService, IInternshipService internshipService) : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<InternResponse>>> GetAll([FromQuery] InternFilter filter)
        {
            var interns = await internService.GetAllInterns(filter);
            return Ok(interns.Select(Mapping.Mapper.Map<InternResponse>));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<InternResponse>> GetById(Guid id)
            => Ok(Mapping.Mapper.Map<InternResponse>(await internService.GetInternById(id)));

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] InternRequest request)
        {
            var internship = await internshipService.FindOrCreate(Internship.Create(request.Internship, [], request.CreateAt, request.UpdateAt));
            var project = await projectService.FindOrCreate(Project.Create(request.Project, [], request.CreateAt, request.UpdateAt));
            var intern = Intern.Create(request.FirstName, request.LastName, Enum.Parse<Gender>(request.Gender),
                request.Email, request.PhoneNumber, request.BirthDate, internship, project, request.CreateAt, request.UpdateAt);

            return Ok(await internService.CreateIntern(intern));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> Update(Guid id, [FromBody] InternRequest request)
        {
            var internship = await internshipService.FindOrCreate(Internship.Create(request.Internship, [], request.CreateAt, request.UpdateAt));
            var project = await projectService.FindOrCreate(Project.Create(request.Project, [], request.CreateAt, request.UpdateAt));
            var intern = Intern.Create(request.FirstName, request.LastName, Enum.Parse<Gender>(request.Gender),
                request.Email, request.PhoneNumber, request.BirthDate, internship, project, request.CreateAt, request.UpdateAt);

            return Ok(await internService.UpdateIntern(id, intern));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            await internService.DeleteIntern(id);

            return Ok(id);
        }

    }
}
