using InternPortal.Domain.Abstractions.Repositories;
using InternPortal.Infrastructure.Data;


namespace InternPortal.Infrastructure.Repositories
{
    public class UnitOfWork(InternPortalDbContext dbContext) : IUnitOfWork
    {
        private IInternRepository? internRepository;

        private IProjectRepository? projectRepository;

        private IInternshipRepository? internshipRepository;

        public IInternRepository InternRepository
        {
            get { return internRepository ??= new InternRepository(dbContext); }
        }

        public IProjectRepository ProjectRepository
        {
            get { return projectRepository ??= new ProjectRepository(dbContext); }
        }

        public IInternshipRepository InternshipRepository
        {
            get { return internshipRepository ??= new InternshipRepository(dbContext); }
        }

        public async Task Save()
           => await dbContext.SaveChangesAsync();

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    dbContext.Dispose();
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
