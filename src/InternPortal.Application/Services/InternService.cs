using InternPortal.Application.Abstractions.Services;
using InternPortal.Domain.Abstractions.Repositories;
using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;


namespace InternPortal.Application.Services
{
    public class InternService(IInternRepository internRepository) : IInternService
    {
        public async Task<Guid> CreateIntern(Intern intern)
        {
            if (!await internRepository.IsEmailUniqueAsync(intern.Email))
                throw new Exception("Email должен быть уникальным");
            if (!await internRepository.IsPhoneNumberUniqueAsync(intern.PhoneNumber))
                throw new Exception("Номер телефона должен быть уникальным");

            return await internRepository.AddAsync(intern);
        }

        public async Task<List<Intern>> GetAllInterns(InternFilter filter)
            => await internRepository.GetAllAsync(filter);

        public async Task<Guid> UpdateIntern(Guid id, Intern intern)
            => await internRepository.UpdateAsync(id, intern);
        
        public async Task DeleteIntern(Guid id)
            => await internRepository.DeleteAsync(id);

        public async Task<Intern?> GetInternById(Guid id)
            => await internRepository.GetByIdAsync(id);
    }
}
