using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;


namespace InternPortal.Domain.Abstractions.Repositories
{
    public interface IInternRepository : IRepository<Intern>
    {
        Task<List<Intern>> GetAllAsync(InternFilter filter);

        Task<bool> IsEmailUniqueAsync(string email);

        Task<bool> IsPhoneNumberUniqueAsync(string? phoneNumber);

    }
}
