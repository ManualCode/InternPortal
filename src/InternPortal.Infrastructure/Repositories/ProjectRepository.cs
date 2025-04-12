using InternPortal.Domain.Abstractions.Repositories;
using InternPortal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternPortal.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
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

        public Task<List<Project>> GetAllAsync()
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
