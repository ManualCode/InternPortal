using InternPortal.Application.Abstractions.Services;
using InternPortal.Domain.Abstractions.Repositories;
using InternPortal.Domain.Models;


namespace InternPortal.Application.Services
{
    public class InternshipService : IInternshipService
    {
        private readonly IInternshipRepository internshipRepository;

        public InternshipService(IInternshipRepository internshipRepository)
        {
            this.internshipRepository = internshipRepository;
        }

        public async Task<List<Internship>> GetAllInternships()
        {
            var internships = await internshipRepository.GetAllAsync();

            return internships;
        }
    }
}
