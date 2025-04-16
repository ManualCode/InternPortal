using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;
using InternPortal.Domain.Pagination;
using InternPortal.Domain.Sort;


namespace InternPortal.Domain.Abstractions.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<List<Project>> GetAllAsync(BaseFilter filter, SortParams sort, PageParams page);
        Task<Project> FindOrCreateAsync(Project project);

    }
}
