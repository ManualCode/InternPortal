using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;
using InternPortal.Domain.Pagination;
using InternPortal.Domain.Sort;


namespace InternPortal.Domain.Abstractions.Repositories
{
    public interface IInternRepository : IRepository<Intern>
    {
        Task<List<Intern>> GetAllAsync();
        Task<bool> IsEmailUniqueAsync(string email);
        Task<bool> IsPhoneNumberUniqueAsync(string phoneNumber);

    }
}
