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
    public class ProjectRepository(InternPortalDbContext dbContext) : IProjectRepository
    {
        public async Task<Guid> AddAsync(Project entity)
        {
            await dbContext.Projects.AddAsync(Mapping.Mapper.Map<ProjectEntity>(entity));
            await dbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var project = dbContext.Projects
                .Include(p => p.Interns)
                .FirstOrDefault(p => p.Id == id)
                ?? throw new Exception("Проект не найден");
               
            if (project.Interns?.Any() == true)
                throw new Exception("Невозможно удалить проект: к нему привязаны стажёры");

            await dbContext.Projects.Where(i => i.Id == id).ExecuteDeleteAsync();
            await dbContext.SaveChangesAsync();
        }

        public async Task<Project> FindOrCreateAsync(Project project)
        {
            var existingProject = await dbContext.Projects.FirstOrDefaultAsync(p => p.Name == project.Name);

            if (existingProject == null)
            {
                existingProject = new ProjectEntity
                {
                    Id = project.Id,
                    Name = project.Name,
                    CreatedAt = DateTime.UtcNow
                };
                dbContext.Projects.Add(existingProject);
                dbContext.SaveChanges();
            }

            return Project.Create(existingProject.Name, [], existingProject.CreatedAt, existingProject.Id);
        }

        public async Task<List<Project>> GetAllAsync(BaseFilter filter, SortParams sort, PageParams page)
        {
            var projectEntities = await dbContext.Projects
                .AsNoTracking()
                .Filter(filter)
                .Include(i => i.Interns)
                    .ThenInclude(x => x.Internship)
                .Sort(sort)
                .Page(page)
                .ToListAsync();

            return projectEntities.Select(Mapping.Mapper.Map<Project>).ToList();
        }

        public async Task<Project?> GetByIdAsync(Guid id)
            => Mapping.Mapper.Map<Project>(
                await dbContext.Projects.Include(i => i.Interns).ThenInclude(x => x.Internship)
                    .FirstOrDefaultAsync(i => i.Id == id));

        public async Task<Guid> UpdateAsync(Guid id, Project entity)
        {
            var projectEntity = await dbContext.Projects.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new Exception("Такого проекта нету");

            projectEntity.Name = entity.Name;

            await dbContext.SaveChangesAsync();

            return id;
        }
    }
}
