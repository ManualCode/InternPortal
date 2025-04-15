using AutoMapper;
using InternPortal.Domain.Models;
using InternPortal.Infrastructure.Entities;
using InternPortal.Shared.Contracts.Intern.Responses;
using InternPortal.Shared.Contracts.Internship.Responses;
using InternPortal.Shared.Contracts.Project.Requests;
using InternPortal.Shared.Contracts.Project.Responses;


namespace InternPortal.Infrastructure.Mappers.Profiles
{
    public class ProjectMapperProfile : Profile
    {
        public ProjectMapperProfile()
        {
            CreateMap<ProjectEntity, Project>()
                .ConstructUsing((ProjectEntity ie) =>
                Project.Create(ie.Name,
                ie.Interns.Select(x => Intern.Create(x.FirstName, x.LastName, (Gender)x.Gender, x.Email, x.PhoneNumber, x.BirthDate, null, null, x.CreatedAt)).ToList(),
                ie.CreatedAt, ie.Id))
                .PreserveReferences();

            CreateMap<Project, ProjectEntity>();

            CreateMap<ProjectRequest, Project>()
                .ConstructUsing((ProjectRequest pr) => Project.Create(pr.Name, null, pr.CreatedAt, null));

            CreateMap<Project, ProjectResponse>()
                .ConstructUsing((Project p) => new ProjectResponse(p.Id, p.Name,
                p.Interns.Select(x =>
                new InternResponse(x.Id, $"{x.FirstName} {x.LastName}", x.Email, x.PhoneNumber,
                new InternshipResponse(x.Internship.Id, x.Internship.Name, new List<InternResponse>(), x.Internship.CreatedAt, x.Internship.UpdatedAt)
                , null, x.CreatedAt, x.UpdatedAt)).ToList(),
                p.CreatedAt, p.UpdatedAt));
        }
    }
}
