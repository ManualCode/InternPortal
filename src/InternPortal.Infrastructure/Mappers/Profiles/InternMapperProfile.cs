using AutoMapper;
using InternPortal.Domain.Models;
using InternPortal.Infrastructure.Entities;
using InternPortal.Shared.Contracts.Intern.Responses;
using InternPortal.Shared.Contracts.Internship.Requests;
using InternPortal.Shared.Contracts.Internship.Responses;
using InternPortal.Shared.Contracts.Project.Responses;


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
                               ie.CreatedAt,
                               ie.Id
                           );
                       })
                       .PreserveReferences();


            CreateMap<Intern, InternEntity>()
                .ForMember(dest => dest.Project, opt => opt.Ignore())
                .ForMember(dest => dest.Internship, opt => opt.Ignore())
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.Project.Id))
                .ForMember(dest => dest.InternshipId, opt => opt.MapFrom(src => src.Internship.Id));

            CreateMap<Intern, InternResponse>()
                .ConstructUsing((Intern i) => new InternResponse(i.Id, $"{i.FirstName} {i.LastName}", i.Email, i.PhoneNumber,
                new InternshipResponse(i.Internship.Id, i.Internship.Name, null, i.Internship.CreatedAt, i.Internship.UpdatedAt),
                new ProjectResponse(i.Project.Id, i.Project.Name, null, i.Project.CreatedAt, i.Project.UpdatedAt),
                i.CreatedAt, i.UpdatedAt))
                 .ForPath(dest => dest.Project.InternIds, opt => opt.Ignore())
                 .ForPath(dest => dest.Internship.InternIds, opt => opt.Ignore());

            CreateMap<InternshipRequest, Internship>()
                .ConstructUsing((InternshipRequest ir) => Internship.Create(ir.Name, ir.interns, ir.CreatedAt, null));
        }
    }
}
