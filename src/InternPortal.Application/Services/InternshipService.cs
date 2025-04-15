using InternPortal.Application.Abstractions.Services;
using InternPortal.Domain.Abstractions.Repositories;
using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;
using InternPortal.Domain.Pagination;
using InternPortal.Domain.Sort;


namespace InternPortal.Application.Services
{
    public class InternshipService : IInternshipService
    {
        private readonly IInternshipRepository internshipRepository;

        public InternshipService(IInternshipRepository internshipRepository)
            => this.internshipRepository = internshipRepository;

        public async Task<Internship> FindOrCreate(Internship internship)
            => await internshipRepository.FindOrCreateAsync(internship);

        public async Task<List<Internship>> GetAllInternships(BaseFilter filter, SortParams sort, PageParams pageParams)
            => await internshipRepository.GetAllAsync(filter, sort, pageParams);

        public Task<Internship?> GetInternshipById(Guid id)
            => internshipRepository.GetByIdAsync(id);

        public async Task DeleteInternship(Guid id)
            => await internshipRepository.DeleteAsync(id);

        public async Task<Guid> CreateInternship(Internship internship)
            => await internshipRepository.AddAsync(internship);

        public async Task<Guid> UpdateInternship(Guid id, Internship entity)
            => await internshipRepository.UpdateAsync(id, entity); 
    }
}
