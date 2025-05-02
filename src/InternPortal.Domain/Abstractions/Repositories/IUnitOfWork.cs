namespace InternPortal.Domain.Abstractions.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IInternRepository InternRepository { get; }
        IProjectRepository ProjectRepository { get; }
        IInternshipRepository InternshipRepository { get; }
        Task Save();
    }
}
