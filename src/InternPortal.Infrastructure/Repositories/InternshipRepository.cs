using InternPortal.Domain.Abstractions.Repositories;
using InternPortal.Domain.Models;
using InternPortal.Infrastructure.Data;
using InternPortal.Infrastructure.Entities;
using InternPortal.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;


namespace InternPortal.Infrastructure.Repositories
{
    public class InternshipRepository : IInternshipRepository
    {
        private readonly InternPortalDbContext dbContext;

        public InternshipRepository(InternPortalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Guid> AddAsync(Internship entity)
        {
            var internshipEntity = Mapping.Mapper.Map<InternshipEntity>(entity);

            await dbContext.Internships.AddAsync(internshipEntity);
            await dbContext.SaveChangesAsync();

            return internshipEntity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            await dbContext.Internships.Where(i => i.Id == id).ExecuteDeleteAsync();
        }

        public async Task<List<Internship>> GetAllAsync()
        {
            var internshipEntities = await dbContext.Internships.AsNoTracking()
                .Include(i => i.Interns).ThenInclude(x => x.Project).ToListAsync();

            var internships = internshipEntities.Select(Mapping.Mapper.Map<Internship>).ToList();

            return internships;
        }

        public Task<Internship?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> UpdateAsync(Guid id, Internship entity)
        {
            throw new NotImplementedException();
        }
    }
}
