using InternPortal.Domain.Models;


namespace InternPortal.Application.Abstractions.Services
{
    public interface IInternService
    {
        Task<Guid> CreateIntern(Intern intern);
        Task<List<Intern>> GetAllInterns();
        Task DeleteIntern(Guid id);
        Task<Guid> UpdateIntern(Guid id, Intern intern);
    }
}