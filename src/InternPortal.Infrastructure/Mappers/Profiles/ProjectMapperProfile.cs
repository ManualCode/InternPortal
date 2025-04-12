using AutoMapper;
using InternPortal.Domain.Models;
using InternPortal.Infrastructure.Entities;


namespace InternPortal.Infrastructure.Mappers.Profiles
{
    public class ProjectMapperProfile : Profile
    {
        public ProjectMapperProfile()
        {
            CreateMap<ProjectEntity, Project>()
                .ConstructUsing((ProjectEntity ie) =>
                Project.Create(ie.Id, ie.Name,
                ie.Interns.Select(x => Intern.Create(x.FirstName, x.LastName, (Gender)x.Gender, x.Email, x.PhoneNumber, x.BirthDate, null, null, x.CreatedAt).Intern).ToList(),
                ie.CreatedAt).Project)
                .PreserveReferences();

            CreateMap<Project, ProjectEntity>();
        }
    }
}
