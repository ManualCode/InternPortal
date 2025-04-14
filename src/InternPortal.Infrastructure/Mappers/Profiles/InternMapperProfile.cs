using AutoMapper;
using InternPortal.Domain.Models;
using InternPortal.Infrastructure.Entities;
using InternPortal.Shared.Contracts.Intern.Responses;


namespace InternPortal.Infrastructure.Mappers.Profiles
{
    public class InternMapperProfile : Profile
    {
        public InternMapperProfile()
        {
            CreateMap<InternEntity, Intern>()
                       .ConstructUsing((InternEntity ie, ResolutionContext context) =>
                       {
                           var internship = ie.Internship != null
                               ? context.Mapper.Map<Internship>(ie.Internship)
                               : null;
                           var project = ie.Project != null
                               ? context.Mapper.Map<Project>(ie.Project)
                               : null;

                           return Intern.Create(
                               ie.FirstName,
                               ie.LastName,
                               (Gender)ie.Gender,
                               ie.Email,
                               ie.PhoneNumber,
                               ie.BirthDate,
                               internship,
                               project,
                               ie.CreatedAt
                           );
                       })
                       .PreserveReferences();


            CreateMap<Intern, InternEntity>()
                .ForMember(dest => dest.Project, opt => opt.Ignore())
                .ForMember(dest => dest.Internship, opt => opt.Ignore())
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.Project.Id))
                .ForMember(dest => dest.InternshipId, opt => opt.MapFrom(src => src.Internship.Id));

            CreateMap<Intern, InternResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
        }
    }
}
