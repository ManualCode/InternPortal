using InternPortal.Application.Abstractions.Services;
using InternPortal.Domain.Abstractions.Repositories;
using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;
using InternPortal.Domain.Sort;


namespace InternPortal.Application.Services
{
    public class InternshipService : IInternshipService
    {
        private readonly IInternshipRepository internshipRepository;

        public InternshipService(IInternshipRepository internshipRepository)
        {
            this.internshipRepository = internshipRepository;
        }

        public async Task<Internship> FindOrCreate(Internship internship)
            => await internshipRepository.FindOrCreateAsync(internship);

        public async Task<List<Internship>> GetAllInternships(InternshipFilter filter, SortParams sort)
        {
            var internships = await internshipRepository.GetAllAsync(filter, sort);

            return internships;
        }
    }
}
