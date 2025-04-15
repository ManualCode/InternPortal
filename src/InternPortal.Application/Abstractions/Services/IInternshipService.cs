using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;
using InternPortal.Domain.Pagination;
using InternPortal.Domain.Sort;


namespace InternPortal.Application.Abstractions.Services
{
    public interface IInternshipService
    {
        Task<List<Internship>> GetAllInternships(BaseFilter filter, SortParams sort, PageParams pageParams);

        Task<Internship?> GetInternshipById(Guid id);

        Task<Internship> FindOrCreate(Internship internship);

        Task DeleteInternship(Guid id);

        Task<Guid> CreateInternship(Internship internship);

        Task<Guid> UpdateInternship(Guid id, Internship entity);
    }
}