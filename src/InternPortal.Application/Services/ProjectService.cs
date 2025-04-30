using InternPortal.Application.Abstractions.Services;
using InternPortal.Domain.Abstractions.Repositories;
using InternPortal.Domain.Pagination;
using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;
using InternPortal.Domain.Sort;


namespace InternPortal.Application.Services
{
    public class ProjectService(IUnitOfWork unitOfWork) : IProjectSevice
    {
        public async Task<Guid> CreateProject(Project project)
        {
            var projectId = await unitOfWork.ProjectRepository.AddAsync(project);
            unitOfWork.Save();
            return projectId;
        }

        public async Task DeleteProject(Guid id)
        {
            await unitOfWork.ProjectRepository.DeleteAsync(id);
            unitOfWork.Save();
        }

        public async Task<Project> FindOrCreate(Project project)
        {
            var p = await unitOfWork.ProjectRepository.FindOrCreateAsync(project);
            unitOfWork.Save();
            return p;
        }

        public async Task<List<Project>> GetAllProject(BaseFilter filter, SortParams sort, PageParams pageParams)
            => await unitOfWork.ProjectRepository.GetAllAsync(filter, sort, pageParams);

        public async Task<Project?> GetProjectById(Guid id)
            => await unitOfWork.ProjectRepository.GetByIdAsync(id);

        public async Task<Guid> UpdateProject(Guid id, Project entity)
        {
            await unitOfWork.ProjectRepository.UpdateAsync(id, entity);
            unitOfWork.Save();
            return id;
        }
    }
}
