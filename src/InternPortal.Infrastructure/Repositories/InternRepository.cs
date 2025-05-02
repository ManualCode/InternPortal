using InternPortal.Domain.Abstractions.Repositories;
using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;
using InternPortal.Infrastructure.Data;
using InternPortal.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace InternPortal.Infrastructure.Repositories
{
    public class InternRepository(InternPortalDbContext dbContext) : IInternRepository
    {
        public async Task<Guid> AddAsync(Intern entity)
        {
            await dbContext.Interns.AddAsync(entity);
            return entity.Id;
        }

        public async Task DeleteAsync(Guid id)
            => await dbContext.Interns.Where(i => i.Id == id).ExecuteDeleteAsync();

        public async Task<List<Intern>> GetAllAsync(InternFilter filter)
        {
            var internEntities = await dbContext.Interns
                .Include(i => i.Internship)
                .Include(i => i.Project)
                .Filter(filter)
                .AsNoTracking()
                .ToListAsync();

            return internEntities.ToList();
        }

        public async Task<Intern?> GetByIdAsync(Guid id)
        {
            var intern = await dbContext.Interns
                .Include(x => x.Project)
                .Include(x => x.Internship)
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == id);

            return intern;
        }

        public async Task<Guid> UpdateAsync(Guid id, Intern entity)
        {
            var internEntity = await dbContext.Interns.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new Exception("Такого стажёра нету");

            internEntity.FirstName = entity.FirstName;
            internEntity.LastName = entity.LastName;
            internEntity.Gender = (int) entity.Gender;
            internEntity.Email = entity.Email;
            internEntity.PhoneNumber = entity.PhoneNumber;
            internEntity.BirthDate = entity.BirthDate;
            internEntity.InternshipId = entity.Internship.Id;
            internEntity.ProjectId = entity.Project.Id;
            internEntity.UpdateAt = DateTime.UtcNow;

            return id;
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
            => !await dbContext.Interns.AnyAsync(u => u.Email == email);

        public async Task<bool> IsPhoneNumberUniqueAsync(string phoneNumber)
            => !await dbContext.Interns.AnyAsync(u => u.PhoneNumber == phoneNumber);
    }
}
