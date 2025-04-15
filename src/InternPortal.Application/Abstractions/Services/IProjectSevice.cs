using InternPortal.Domain.Pagination;
using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;
using InternPortal.Domain.Sort;

namespace InternPortal.Application.Abstractions.Services
{
    public interface IProjectSevice
    {
        Task<Guid> CreateProject(Project project);

        Task DeleteProject(Guid id);

        Task<Project> FindOrCreate(Project project);

        Task<List<Project>> GetAllProject(BaseFilter filter, SortParams sort, PageParams pageParams);

        Task<Project?> GetProjectById(Guid id);

        Task<Guid> UpdateProject(Guid id, Project footballer);
    }
}
