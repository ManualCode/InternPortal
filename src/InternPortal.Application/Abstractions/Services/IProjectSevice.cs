using InternPortal.Domain.Pagination;
using InternPortal.Domain.Filters;
using InternPortal.Domain.Sort;
using InternPortal.Shared.Contracts.Project.Responses;
using InternPortal.Shared.Contracts.Project.Requests;

namespace InternPortal.Application.Abstractions.Services
{
    public interface IProjectSevice
    {
        Task<Guid> CreateProject(ProjectRequest projectRequest);

        Task DeleteProject(Guid id);

        Task<PagedProjectResponse> GetAllProject(BaseFilter filter, SortParams sort, PageParams pageParams);

        Task<ProjectResponse?> GetProjectById(Guid id);

        Task<Guid> UpdateProject(Guid id, ProjectRequest projectRequest);
    }
}
