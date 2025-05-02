using InternPortal.Shared.Contracts.Project.Responses;
using InternPortal.Application.Abstractions.Services;
using InternPortal.Shared.Contracts.Project.Requests;
using InternPortal.Domain.Abstractions.Repositories;
using InternPortal.Infrastructure.Mappers;
using InternPortal.Domain.Pagination;
using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;
using InternPortal.Domain.Sort;


namespace InternPortal.Application.Services
{
    public class ProjectService(IUnitOfWork unitOfWork) : IProjectSevice
    {
        public async Task<Guid> CreateProject(ProjectRequest projectRequest)
        {
            var projectId = await unitOfWork.ProjectRepository.AddAsync(Mapping.Mapper.Map<Project>(projectRequest));
            await unitOfWork.Save();
            return projectId;
        }

        public async Task DeleteProject(Guid id)
        {
            await unitOfWork.ProjectRepository.DeleteAsync(id);
            await unitOfWork.Save();
        }

        public async Task<PagedProjectResponse> GetAllProject(BaseFilter filter, SortParams sort, PageParams pageParams)
        {
            var projects = await unitOfWork.ProjectRepository.GetAllAsync(filter, sort, pageParams);
            return Mapping.Mapper.Map<PagedProjectResponse>(projects);
        }

        public async Task<ProjectResponse?> GetProjectById(Guid id)
        {
            var project = await unitOfWork.ProjectRepository.GetByIdAsync(id);
            return Mapping.Mapper.Map<ProjectResponse>(project);
        }

        public async Task<Guid> UpdateProject(Guid id, ProjectRequest projectRequest)
        {
            await unitOfWork.ProjectRepository.UpdateAsync(id, Mapping.Mapper.Map<Project>(projectRequest));
            await unitOfWork.Save();
            return id;
        }
    }
}
