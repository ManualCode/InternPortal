using InternPortal.Domain.Abstractions.Repositories;
using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;
using InternPortal.Domain.Sort;
using InternPortal.Infrastructure.Data;
using InternPortal.Infrastructure.Entities;
using InternPortal.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace InternPortal.Infrastructure.Repositories
{
    public class InternRepository : IInternRepository
    {
        private readonly InternPortalDbContext dbContext;

        public InternRepository(InternPortalDbContext dbContext)
            => this.dbContext = dbContext;

        public async Task<Guid> AddAsync(Intern entity)
        {

            var internEntity = Mapping.Mapper.Map<InternEntity>(entity);

            await dbContext.Interns.AddAsync(internEntity);
            await dbContext.SaveChangesAsync();

            return internEntity.Id;
        }


        public async Task DeleteAsync(Guid id)
            => await dbContext.Interns.Where(i => i.Id == id).ExecuteDeleteAsync();

        public async Task<List<Intern>> GetAllAsync(InternshipFilter filter, SortParams sort)
        {
            var internEntities = await dbContext.Interns.AsNoTracking()
                .Include(i => i.Internship).Include(i => i.Project).ToListAsync();

            var interns = internEntities.Select(Mapping.Mapper.Map<Intern>).ToList();

            return interns;
        }

        public async Task<Intern?> GetByIdAsync(Guid id)
        {
            var internEntity = await dbContext.Interns.FirstOrDefaultAsync(i => i.Id == id);

            return Mapping.Mapper.Map<Intern>(internEntity);
        }

        public Task<Guid> UpdateAsync(Guid id, Intern entity)
        {
            throw new NotImplementedException();
        }
    }
}
