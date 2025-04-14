using InternPortal.Application.Abstractions.Services;
using InternPortal.Domain.Abstractions.Repositories;
using InternPortal.Domain.Models;


namespace InternPortal.Application.Services
{
    public class InternService: IInternService
    {
        private readonly IInternRepository internRepository;
        private readonly IInternshipRepository internshipRepository;
        private readonly IProjectRepository projectRepository;

        public InternService(IInternRepository internRepository,
            IInternshipRepository internshipRepository, IProjectRepository projectRepository)
        {
            this.internRepository = internRepository;
            this.internshipRepository = internshipRepository;
            this.projectRepository = projectRepository;
        }

        public async Task<Guid> CreateIntern(Intern intern)
        {
            var internId = await internRepository.AddAsync(intern);

            return internId;
        }

        public async Task<List<Intern>> GetAllInterns()
        {
            var interns = await internRepository.GetAllAsync(null, null);

            return interns;
        }

        public async Task<Guid> UpdateIntern(Guid id, Intern intern)
        {
            var footballerId = await internRepository.UpdateAsync(id, intern);

            return id;
        }
        
        public async Task DeleteIntern(Guid id)
        {
            await internRepository.DeleteAsync(id);
        }
    }
}
