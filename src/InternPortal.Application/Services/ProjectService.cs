using InternPortal.Application.Abstractions.Services;
using InternPortal.Domain.Abstractions.Repositories;
using InternPortal.Domain.Models;


namespace InternPortal.Application.Services
{
    public class ProjectService: IProjectSevice
    {
        private readonly IProjectRepository projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task<Project> FindOrCreate(Project project)
           =>  await projectRepository.FindOrCreateAsync(project);
        
    }
}
