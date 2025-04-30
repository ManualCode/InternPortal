using InternPortal.Application.Abstractions.Services;
using InternPortal.Domain.Abstractions.Repositories;
using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;
using InternPortal.Domain.Pagination;
using InternPortal.Domain.Sort;


namespace InternPortal.Application.Services
{
    public class InternshipService(IUnitOfWork unitOfWork) : IInternshipService
    {
        public async Task<Internship> FindOrCreate(Internship internship)
        {
            var i = await unitOfWork.InternshipRepository.FindOrCreateAsync(internship);
            unitOfWork.Save();
            return i;
        }

        public async Task<List<Internship>> GetAllInternships(BaseFilter filter, SortParams sort, PageParams pageParams)
            => await unitOfWork.InternshipRepository.GetAllAsync(filter, sort, pageParams);

        public Task<Internship?> GetInternshipById(Guid id)
            => unitOfWork.InternshipRepository.GetByIdAsync(id);

        public async Task DeleteInternship(Guid id)
        {
            await unitOfWork.InternshipRepository.DeleteAsync(id);
            unitOfWork.Save();
        }

        public async Task<Guid> CreateInternship(Internship internship)
        {
            var internshipId = await unitOfWork.InternshipRepository.AddAsync(internship);
            unitOfWork.Save();
            return internshipId;
        }

        public async Task<Guid> UpdateInternship(Guid id, Internship entity)
        {
            var internshipId =  await unitOfWork.InternshipRepository.UpdateAsync(id, entity);
            unitOfWork.Save();
            return internshipId;
        }
    }
}
