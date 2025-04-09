using InternPortal.Domain.Models;


namespace InternPortal.Domain.Abstractions.Repositories
{
    public interface IInternRepository: IRepository<Intern>
    {
        Task<Intern> FindOrCreateAsync(Intern intern);
    }
}
