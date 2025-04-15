using InternPortal.Application.Abstractions.Services;
using InternPortal.Domain.Models;
using InternPortal.Shared.Contracts.Intern.Requests;
using InternPortal.Shared.Contracts.Intern.Responses;
using InternPortal.Shared.Contracts.Internship.Responses;
using InternPortal.Shared.Contracts.Project.Responses;
using Microsoft.AspNetCore.Mvc;


namespace InternPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class InternController : Controller
    {
        private readonly IInternService internService;
        private readonly IProjectSevice projectService;
        private readonly IInternshipService internshipService;

        public InternController(IInternService internService, IProjectSevice projectService, IInternshipService internshipService)
        {
            this.internService = internService;
            this.projectService = projectService;
            this.internshipService = internshipService;
        }

        [HttpGet]
        public async Task<ActionResult<List<InternResponse>>> GetInterns()
        {
            var interns = await internService.GetAllInterns();

            var responses = interns.Select(i => new InternResponse(i.Id, $"{i.FirstName} {i.LastName}", i.Email, i.PhoneNumber,
                new InternshipResponse(i.Internship.Id, i.Internship.Name, new List<InternResponse>(), i.Internship.CreatedAt, i.Internship.UpdatedAt),
                new ProjectResponse(i.Project.Id, i.Project.Name, new List<InternResponse>(), i.Project.CreatedAt, i.Project.UpdatedAt),
                i.CreatedAt, i.UpdatedAt));

            return Ok(responses);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateIntern([FromBody] InternRequest request)
        {
            var internship = await internshipService.FindOrCreate(Internship.Create(request.Internship, [], request.CreatedAt));
            var project = await projectService.FindOrCreate(Project.Create(request.Project, [], request.CreatedAt));

            var intern = Intern.Create(request.FirstName, request.LastName, Enum.Parse<Gender>(request.Gender),
                request.Email, request.PhoneNumber, request.BirthDate, internship, project, request.CreatedAt);

            return Ok(await internService.CreateIntern(intern));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateIntern(Guid id, [FromBody] InternRequest request)
        {
            var internship = Internship.Create(request.Internship, [], request.CreatedAt);
            var project = Project.Create(request.Project, [], request.CreatedAt);

            var intern = Intern.Create(request.FirstName, request.LastName, Enum.Parse<Gender>(request.Gender),
                request.Email, request.PhoneNumber, request.BirthDate, internship, project, request.CreatedAt);

            return Ok(await internService.UpdateIntern(id, intern));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteIntern(Guid id)
        {
            await internService.DeleteIntern(id);

            return Ok(id);
        }

    }
}
