using InternPortal.Domain.Abstractions.Repositories;
using InternPortal.Infrastructure.Extensions;
using InternPortal.Infrastructure.Entities;
using InternPortal.Infrastructure.Mappers;
using InternPortal.Infrastructure.Data;
using InternPortal.Domain.Pagination;
using Microsoft.EntityFrameworkCore;
using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;
using InternPortal.Domain.Sort;


namespace InternPortal.Infrastructure.Repositories
{
    public class InternshipRepository(InternPortalDbContext dbContext) : IInternshipRepository
    {
        public async Task<Guid> AddAsync(Internship entity)
        {
            var existingInterns = await dbContext.Interns
                .Where(i => entity.InternIds.Contains(i.Id))
                .ToListAsync();

            var projectEntity = new InternshipEntity
            {
                Id = entity.Id,
                Name = entity.Name,
                Interns = existingInterns,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };

            await dbContext.Internships.AddAsync(projectEntity);
            await dbContext.SaveChangesAsync();

            return projectEntity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var internship = dbContext.Internships
                .Include(p => p.Interns)
                .FirstOrDefault(p => p.Id == id)
                ?? throw new Exception("Направление не найдено");

            if (internship.Interns?.Any() == true)
                throw new Exception("Невозможно удалить направление стажировки: к нему привязаны стажёры");

            await dbContext.Internships.Where(i => i.Id == id).ExecuteDeleteAsync();
            await dbContext.SaveChangesAsync();
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

            return Internship.Create(existingInternship.Name, [], existingInternship.CreatedAt, existingInternship.Id);
        }

        public async Task<List<Internship>> GetAllAsync(BaseFilter filter, SortParams sort, PageParams pageParams)
        {
            var internshipEntities = await dbContext.Internships
                .AsNoTracking()
                .Filter(filter)
                .Include(i => i.Interns)
                    .ThenInclude(x => x.Project)
                .Sort(sort)
                .Page(pageParams)
                .ToListAsync();

            return internshipEntities.Select(Mapping.Mapper.Map<Internship>).ToList();
        }

        public async Task<Internship?> GetByIdAsync(Guid id)
            => Mapping.Mapper.Map<Internship>(
                await dbContext.Internships.Include(i => i.Interns).ThenInclude(x => x.Project)
                    .FirstOrDefaultAsync(i => i.Id == id));

        public async Task<Guid> UpdateAsync(Guid id, Internship entity)
        {
            var internshipEntity = await dbContext.Internships.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new Exception("Такого направления нету");

            var existingInterns = await dbContext.Interns
                .Where(i => entity.InternIds.Contains(i.Id))
                .ToListAsync();

            internshipEntity.Name = entity.Name;
            internshipEntity.Interns = existingInterns;

            await dbContext.SaveChangesAsync();

            return id;
        }
    }
}
