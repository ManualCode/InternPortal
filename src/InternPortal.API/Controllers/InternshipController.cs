using InternPortal.Application.Abstractions.Services;
using InternPortal.Shared.Contracts.Intern.Responses;
using Microsoft.AspNetCore.Mvc;
using InternPortal.Shared.Contracts.Internship.Responses;
using InternPortal.Shared.Contracts.Project.Responses;

namespace InternPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class InternshipController : Controller
    {
        private readonly IInternshipService internshipService;

        public InternshipController(IInternshipService internshipService)
        {
            this.internshipService = internshipService;
        }

        [HttpGet]
        public async Task<ActionResult<List<InternResponse>>> GetInternships()
        {
            var internships = await internshipService.GetAllInternships();

            var responses = internships.Select(i => new InternshipResponse(i.Id, i.Name,
                i.Interns.Select(x => 
                new InternResponse(x.Id, $"{x.FirstName} {x.LastName}",x.Email, x.PhoneNumber, null,
                new ProjectResponse(x.Project.Id, x.Project.Name, new List<InternResponse>(), x.Project.CreatedAt, x.Project.UpdatedAt),
                x.CreatedAt, x.UpdatedAt)).ToList(),
                i.CreatedAt, i.UpdatedAt));

            return Ok(responses);
        }
    }
}
