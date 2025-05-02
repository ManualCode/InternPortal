using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;
using InternPortal.Domain.Pagination;
using InternPortal.Domain.Sort;


namespace InternPortal.Domain.Abstractions.Repositories
{
    public interface IInternshipRepository : IRepository<Internship>
    {
        Task<PagedResult<Internship>> GetAllAsync(BaseFilter filter, SortParams sort, PageParams pageParams);
        Task<Internship> FindOrCreateAsync(string name);
    }
}
