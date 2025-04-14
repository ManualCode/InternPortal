using InternPortal.Domain.Abstractions.Repositories;
using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;
using InternPortal.Domain.Sort;
using InternPortal.Infrastructure.Data;
using InternPortal.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternPortal.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly InternPortalDbContext dbContext;

        public ProjectRepository(InternPortalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<Guid> AddAsync(Project entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Project entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
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

            return Project.Create(existingProject.Id, existingProject.Name, [], existingProject.CreatedAt).Project;
        }

        public Task<List<Project>> GetAllAsync(InternshipFilter filter, SortParams sort)
        {
            throw new NotImplementedException();
        }

        public Task<Project?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> UpdateAsync(Guid id, Project entity)
        {
            throw new NotImplementedException();
        }
    }
}
