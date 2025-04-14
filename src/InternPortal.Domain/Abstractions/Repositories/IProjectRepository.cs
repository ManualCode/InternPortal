using InternPortal.Domain.Models;

namespace InternPortal.Domain.Abstractions.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<Project> FindOrCreateAsync(Project project);
    }
}
