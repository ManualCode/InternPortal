using InternPortal.Domain.Models;


namespace InternPortal.Domain.Abstractions.Repositories
{
    public interface IInternshipRepository : IRepository<Internship>
    {
        Task<Internship> FindOrCreateAsync(Internship internship);
    }
}
