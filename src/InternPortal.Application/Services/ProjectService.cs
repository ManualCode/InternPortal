using InternPortal.Application.Abstractions.Services;
using InternPortal.Domain.Abstractions.Repositories;
using InternPortal.Domain.Pagination;
using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;
using InternPortal.Domain.Sort;


namespace InternPortal.Application.Services
{
    public class ProjectService(IProjectRepository projectRepository) : IProjectSevice
    {
        public async Task<Guid> CreateProject(Project project)
            => await projectRepository.AddAsync(project);

        public async Task DeleteProject(Guid id)
            => await projectRepository.DeleteAsync(id);

        public async Task<Project> FindOrCreate(Project project)
            => await projectRepository.FindOrCreateAsync(project);

        public async Task<List<Project>> GetAllProject(BaseFilter filter, SortParams sort, PageParams pageParams)
            => await projectRepository.GetAllAsync(filter, sort, pageParams);

        public async Task<Project?> GetProjectById(Guid id)
            => await projectRepository.GetByIdAsync(id);

        public async Task<Guid> UpdateProject(Guid id, Project entity)
            => await projectRepository.UpdateAsync(id, entity);

    }
}
