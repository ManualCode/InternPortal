using InternPortal.Domain.Abstractions.Repositories;
using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;
using InternPortal.Domain.Sort;
using InternPortal.Infrastructure.Data;
using InternPortal.Infrastructure.Entities;
using InternPortal.Infrastructure.Extensions;
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

        public async Task<Internship> FindOrCreateAsync(Internship internship)
        {
            var existingInternship = await dbContext.Internships.FirstOrDefaultAsync(i => i.Name == internship.Name);

            if (existingInternship == null)
            {
                existingInternship = new InternshipEntity
                {
                    Id = internship.Id,
                    Name = internship.Name,
                    CreatedAt = DateTime.UtcNow
                };
                dbContext.Internships.Add(existingInternship);
                dbContext.SaveChanges();
            }

            return Internship.Create(existingInternship.Id, existingInternship.Name, [], existingInternship.CreatedAt).Internship;
        }

        public async Task<List<Internship>> GetAllAsync(InternshipFilter filter, SortParams sort)
        {
            var internshipEntities = await dbContext.Internships.AsNoTracking().Filter(filter)
                .Include(i => i.Interns).ThenInclude(x => x.Project).Sort(sort).ToListAsync();

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
