using AutoMapper;
using InternPortal.Domain.Models;
using InternPortal.Shared.Contracts.Intern.Requests;
using InternPortal.Shared.Contracts.Intern.Responses;


namespace InternPortal.Infrastructure.Mappers.Profiles
{
    public class InternMapperProfile : Profile
    {
        public InternMapperProfile()
        {
            CreateMap<Intern, InternResponse>()
                .ConstructUsing((Intern i) => new InternResponse(i.Id, i.FirstName, i.LastName, i.Gender.ToString(), i.BirthDate, i.Email, i.PhoneNumber,
                i.Internship.Name, i.Project.Name, i.CreateAt, i.UpdateAt))
                .ForMember(dest => dest.Internship, opt => opt.MapFrom(src => src.Internship.Name))
                .ForMember(dest => dest.Project, opt => opt.MapFrom(src => src.Project.Name));

            CreateMap<InternRequest, Intern>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => (int)Enum.Parse<Gender>(src.Gender)))
                .ForMember(dest => dest.Internship, opt => opt.Ignore())
                .ForMember(dest => dest.Project, opt => opt.Ignore());
        }
    }
}
