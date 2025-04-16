using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;


namespace InternPortal.Application.Abstractions.Services
{
    public interface IInternService
    {
        Task<Guid> CreateIntern(Intern intern);

        Task<List<Intern>> GetAllInterns(InternFilter filter);

        Task DeleteIntern(Guid id);

        Task<Guid> UpdateIntern(Guid id, Intern intern);

        Task<Intern?> GetInternById (Guid id);
    }
}