using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;
using InternPortal.Domain.Sort;


namespace InternPortal.Application.Abstractions.Services
{
    public interface IInternshipService
    {
        Task<List<Internship>> GetAllInternships(InternshipFilter filter, SortParams sort);

        Task<Internship> FindOrCreate(Internship internship);
    }
}