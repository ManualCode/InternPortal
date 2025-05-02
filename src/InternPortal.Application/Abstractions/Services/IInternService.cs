using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;
using InternPortal.Shared.Contracts.Intern.Requests;
using InternPortal.Shared.Contracts.Intern.Responses;


namespace InternPortal.Application.Abstractions.Services
{
    public interface IInternService
    {
        Task<Guid> CreateIntern(InternRequest internRequest);

        Task<List<InternResponse>> GetAllInterns(InternFilter filter);

        Task DeleteIntern(Guid id);

        Task<Guid> UpdateIntern(Guid id, InternRequest internRequest);

        Task<Intern?> GetInternById (Guid id);
    }
}