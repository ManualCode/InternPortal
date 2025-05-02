using InternPortal.Application.Abstractions.Services;
using InternPortal.Domain.Abstractions.Repositories;
using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;
using InternPortal.Domain.Pagination;
using InternPortal.Domain.Sort;
using InternPortal.Infrastructure.Mappers;
using InternPortal.Shared.Contracts.Internship.Requests;
using InternPortal.Shared.Contracts.Internship.Responses;


namespace InternPortal.Application.Services
{
    public class InternshipService(IUnitOfWork unitOfWork) : IInternshipService
    {
        public async Task<PagedInternshipResponse> GetAllInternships(BaseFilter filter, SortParams sort, PageParams pageParams)
        {
            var internships = await unitOfWork.InternshipRepository.GetAllAsync(filter, sort, pageParams);
            return Mapping.Mapper.Map<PagedInternshipResponse>(internships);
        }

        public async Task<InternshipResponse?> GetInternshipById(Guid id)
        {
            var internship = await unitOfWork.InternshipRepository.GetByIdAsync(id);
            return Mapping.Mapper.Map<InternshipResponse>(internship);
        }

        public async Task DeleteInternship(Guid id)
        {
            await unitOfWork.InternshipRepository.DeleteAsync(id);
            await unitOfWork.Save();
        }

        public async Task<Guid> CreateInternship(InternshipRequest internshipRequest)
        {
            var internshipId = await unitOfWork.InternshipRepository.AddAsync(Mapping.Mapper.Map<Internship>(internshipRequest));
            await unitOfWork.Save();
            return internshipId;
        }

        public async Task<Guid> UpdateInternship(Guid id, InternshipRequest internshipRequest)
        {
            var internshipId =  await unitOfWork.InternshipRepository.UpdateAsync(id, Mapping.Mapper.Map<Internship>(internshipRequest));
            await unitOfWork.Save();
            return internshipId;
        }
    }
}
