using InternPortal.Domain.Filters;
using InternPortal.Domain.Pagination;
using InternPortal.Domain.Sort;
using InternPortal.Shared.Contracts.Internship.Requests;
using InternPortal.Shared.Contracts.Internship.Responses;


namespace InternPortal.Application.Abstractions.Services
{
    public interface IInternshipService
    {
        Task<PagedInternshipResponse> GetAllInternships(BaseFilter filter, SortParams sort, PageParams pageParams);

        Task<InternshipResponse?> GetInternshipById(Guid id);

        Task DeleteInternship(Guid id);

        Task<Guid> CreateInternship(InternshipRequest internship);

        Task<Guid> UpdateInternship(Guid id, InternshipRequest internshipRequest);
    }
}