using InternPortal.Shared.Contracts.Intern.Responses;
using InternPortal.Application.Abstractions.Services;
using InternPortal.Domain.Abstractions.Repositories;
using InternPortal.Shared.Contracts.Intern.Requests;
using InternPortal.Infrastructure.Mappers;
using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;


namespace InternPortal.Application.Services
{
    public class InternService(IUnitOfWork unitOfWork) : IInternService
    {
        public async Task<Guid> CreateIntern(InternRequest internRequest)
        {
            if (!await unitOfWork.InternRepository.IsEmailUniqueAsync(internRequest.Email))
                throw new Exception("Email должен быть уникальным");
            if (!string.IsNullOrWhiteSpace(internRequest.PhoneNumber)
                && !await unitOfWork.InternRepository.IsPhoneNumberUniqueAsync(internRequest.PhoneNumber))
                throw new Exception("Номер телефона должен быть уникальным");

            var internship = await unitOfWork.InternshipRepository.FindOrCreateAsync(internRequest.Internship);
            var project = await unitOfWork.ProjectRepository.FindOrCreateAsync(internRequest.Project);

            var intern = Mapping.Mapper.Map<Intern>(internRequest);
            intern.Internship = internship;
            intern.Project = project;

            var internId = await unitOfWork.InternRepository.AddAsync(intern);
            await unitOfWork.Save();
            return internId;
        }

        public async Task<Guid> UpdateIntern(Guid id, InternRequest internRequest)
        {
            if (!await unitOfWork.InternRepository.IsEmailUniqueAsync(internRequest.Email, id))
                throw new Exception("Email должен быть уникальным");
            if (!string.IsNullOrWhiteSpace(internRequest.PhoneNumber)
                && !await unitOfWork.InternRepository.IsPhoneNumberUniqueAsync(internRequest.PhoneNumber, id))
                throw new Exception("Номер телефона должен быть уникальным");

            var internship = await unitOfWork.InternshipRepository.FindOrCreateAsync(internRequest.Internship);
            var project = await unitOfWork.ProjectRepository.FindOrCreateAsync(internRequest.Project);

            var intern = Mapping.Mapper.Map<Intern>(internRequest);
            intern.Internship = internship;
            intern.Project = project;

            await unitOfWork.InternRepository.UpdateAsync(id, intern);
            await unitOfWork.Save();
            return id;
        }

        public async Task<List<InternResponse>> GetAllInterns(InternFilter filter)
        {
            var interns = await unitOfWork.InternRepository.GetAllAsync(filter);
            return interns.Select(Mapping.Mapper.Map<InternResponse>).ToList();
        }

        public async Task<InternResponse?> GetInternById(Guid id)
        {
            var intern = await unitOfWork.InternRepository.GetByIdAsync(id);
            return Mapping.Mapper.Map<InternResponse>(intern);
        }

        public async Task DeleteIntern(Guid id)
        {
            await unitOfWork.InternRepository.DeleteAsync(id);
            await unitOfWork.Save();
        }
    }
}
