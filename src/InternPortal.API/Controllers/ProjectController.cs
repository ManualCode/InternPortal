using InternPortal.Shared.Contracts.Project.Responses;
using InternPortal.Application.Abstractions.Services;
using InternPortal.Shared.Contracts.Project.Requests;
using InternPortal.Infrastructure.Mappers;
using InternPortal.Domain.Pagination;
using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;
using InternPortal.Domain.Sort;
using Microsoft.AspNetCore.Mvc;


namespace InternPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProjectController(IProjectSevice projectService) : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<ProjectResponse>>> GetAll([FromQuery] BaseFilter filter, [FromQuery] SortParams sort, [FromQuery] PageParams pageParams)
        {
            var projects = await projectService.GetAllProject(filter, sort, pageParams);

            return Ok(projects.Select(Mapping.Mapper.Map<ProjectResponse>));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProjectResponse>> GetById(Guid id)
            => Ok(Mapping.Mapper.Map<ProjectResponse>(await projectService.GetProjectById(id)));

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] ProjectRequest request)
            => Ok(await projectService.CreateProject(Mapping.Mapper.Map<Project>(request)));

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> Update(Guid id, [FromBody] ProjectRequest request)
            => Ok(await projectService.UpdateProject(id, Mapping.Mapper.Map<Project>(request)));

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteById(Guid id)
        {
            await projectService.DeleteProject(id);
            return Ok(id);
        }
    }
}
