using InternPortal.Application.Abstractions.Services;
using InternPortal.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using InternPortal.Shared.Contracts.Intern.Responses;


namespace InternPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class InternController : Controller
    {
        private readonly IInternService internService;

        public InternController(IInternService internService)
        {
            this.internService = internService;
        }

        [HttpGet]
        public async Task<ActionResult<List<InternResponse>>> GetInterns()
        {
            var interns = await internService.GetAllInterns();

            var responses = interns.Select(i => new InternResponse(i.Id, $"{i.FirstName} {i.LastName}", i.Email,i.PhoneNumber,
                new InternshipResponse(i.Internship.Id, i.Internship.Name, new List<InternResponse>(), i.Internship.CreatedAt, i.Internship.UpdatedAt),
                new ProjectResponse(i.Project.Id, i.Project.Name, new List<InternResponse>(), i.Project.CreatedAt, i.Project.UpdatedAt),
                i.CreatedAt, i.UpdatedAt));

            return Ok(responses);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateIntern([FromBody] InternRequest request)
        {
            var internship = Internship.Create(Guid.NewGuid(), request.Internship, [], request.CreatedAt).Internship;
            var project = Project.Create(Guid.NewGuid(), request.Project, [], request.CreatedAt).Project;

            var intern = Intern.Create(request.FirstName, request.LastName, Enum.Parse<Gender>(request.Gender),
                request.Email, request.PhoneNumber, request.BirthDate, internship, project, request.CreatedAt).Intern;

            return Ok(await internService.CreateIntern(intern));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateIntern(Guid id, [FromBody] InternRequest request)
        {
            var internship = Internship.Create(Guid.NewGuid(), request.Internship, [], request.CreatedAt).Internship;
            var project = Project.Create(Guid.NewGuid(), request.Project, [], request.CreatedAt).Project;

            var intern = Intern.Create(request.FirstName, request.LastName, Enum.Parse<Gender>(request.Gender),
                request.Email, request.PhoneNumber, request.BirthDate, internship, project, request.CreatedAt).Intern;

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
