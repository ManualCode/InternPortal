namespace InternPortal.Domain.Abstractions.Repositories
{
    public interface IRepository<T>
    {
        Task<IQueryable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task<T?> GetByIdAsync(Guid id);
        Task DeleteAsync(T entity);
    }
}
