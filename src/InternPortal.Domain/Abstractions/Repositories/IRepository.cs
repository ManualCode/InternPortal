using InternPortal.Domain.Filters;
using InternPortal.Domain.Sort;

namespace InternPortal.Domain.Abstractions.Repositories
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync(InternshipFilter filter, SortParams sort);
        Task<Guid> AddAsync(T entity);
        Task<T?> GetByIdAsync(Guid id);

        Task<Guid> UpdateAsync(Guid id, T entity);

        Task DeleteAsync(Guid id);
    }
}
