using AutoMapper;
using InternPortal.Domain.Models;
using InternPortal.Infrastructure.Entities;


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
                           ).Intern;
                       })
                       .PreserveReferences();


            CreateMap<Intern, InternEntity>();

        }
    }
}
