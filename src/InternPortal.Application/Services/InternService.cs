using InternPortal.Application.Abstractions.Services;
using InternPortal.Domain.Abstractions.Repositories;
using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;


namespace InternPortal.Application.Services
{
    public class InternService(IUnitOfWork unitOfWork) : IInternService
    {
        public async Task<Guid> CreateIntern(Intern intern)
        {
            if (!await unitOfWork.InternRepository.IsEmailUniqueAsync(intern.Email))
                throw new Exception("Email должен быть уникальным");
            if (!string.IsNullOrWhiteSpace(intern.PhoneNumber) 
                && !await unitOfWork.InternRepository.IsPhoneNumberUniqueAsync(intern.PhoneNumber))
                throw new Exception("Номер телефона должен быть уникальным");

            var internId = await unitOfWork.InternRepository.AddAsync(intern);
            unitOfWork.Save();
            return internId;
        }
        public async Task<Guid> UpdateIntern(Guid id, Intern intern)
        {
            await unitOfWork.InternRepository.UpdateAsync(id, intern);
            unitOfWork.Save();
            return id;
        }

        public async Task<List<Intern>> GetAllInterns(InternFilter filter)
            => await unitOfWork.InternRepository.GetAllAsync(filter);

        public async Task<Intern?> GetInternById(Guid id)
            => await unitOfWork.InternRepository.GetByIdAsync(id);

        public async Task DeleteIntern(Guid id)
        {
            await unitOfWork.InternRepository.DeleteAsync(id);
            unitOfWork.Save();
        }
    }
}
