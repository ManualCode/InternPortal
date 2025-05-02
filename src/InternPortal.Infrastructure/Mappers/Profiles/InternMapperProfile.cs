using AutoMapper;
using InternPortal.Domain.Models;
using InternPortal.Shared.Contracts.Intern.Requests;
using InternPortal.Shared.Contracts.Intern.Responses;
using InternPortal.Shared.Contracts.Internship.Responses;
using InternPortal.Shared.Contracts.Project.Responses;


namespace InternPortal.Infrastructure.Mappers.Profiles
{
    public class InternMapperProfile : Profile
    {
        public InternMapperProfile()
        {
            CreateMap<Intern, InternResponse>()
                .ConstructUsing((Intern i) => new InternResponse(i.Id, $"{i.FirstName} {i.LastName}", i.Gender.ToString() ,i.BirthDate, i.Email, i.PhoneNumber,
                new InternshipResponse(i.Internship.Id, i.Internship.Name, null, i.Internship.CreatedAt, i.Internship.UpdatedAt),
                new ProjectResponse(i.Project.Id, i.Project.Name, null, i.Project.CreatedAt, i.Project.UpdatedAt), i.CreateAt, i.UpdateAt))
                 .ForPath(dest => dest.Project.Interns, opt => opt.Ignore())
                 .ForPath(dest => dest.Internship.Interns, opt => opt.Ignore());

            CreateMap<InternRequest, Intern>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => (int)Enum.Parse<Gender>(src.Gender)))
                .ForMember(dest => dest.Internship, opt => opt.Ignore())
                .ForMember(dest => dest.Project, opt => opt.Ignore());
        }
    }
}
