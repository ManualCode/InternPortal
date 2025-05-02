using InternPortal.Shared.Contracts.Project.Responses;
using InternPortal.Application.Abstractions.Services;
using InternPortal.Shared.Contracts.Project.Requests;
using InternPortal.Domain.Pagination;
using InternPortal.Domain.Filters;
using InternPortal.Domain.Sort;
using Microsoft.AspNetCore.Mvc;


namespace InternPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProjectController(IProjectSevice projectService) : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<ProjectResponse>>> GetAll([FromQuery] BaseFilter filter,
            [FromQuery] SortParams sort, [FromQuery] PageParams pageParams)
            => Ok(await projectService.GetAllProject(filter, sort, pageParams));

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProjectResponse>> GetById(Guid id)
            => Ok(await projectService.GetProjectById(id));

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] ProjectRequest request)
            => Ok(await projectService.CreateProject(request));

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> Update(Guid id, [FromBody] ProjectRequest request)
            => Ok(await projectService.UpdateProject(id, request));

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteById(Guid id)
        {
            await projectService.DeleteProject(id);
            return Ok(id);
        }
    }
}
