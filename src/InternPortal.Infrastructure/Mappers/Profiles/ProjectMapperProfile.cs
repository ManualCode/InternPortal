using AutoMapper;
using InternPortal.Domain.Models;
using InternPortal.Infrastructure.Entities;
using InternPortal.Shared.Contracts.Project.Requests;
using InternPortal.Shared.Contracts.Project.Responses;


namespace InternPortal.Infrastructure.Mappers.Profiles
{
    public class ProjectMapperProfile : Profile
    {
        public ProjectMapperProfile()
        {
            CreateMap<ProjectEntity, Project>()
                .ConstructUsing((ProjectEntity pe) =>
                Project.Create(pe.Name, pe.Interns.Select(x => x.Id).ToList(), pe.CreatedAt, pe.Id))
                .PreserveReferences();

            CreateMap<Project, ProjectEntity>();

            CreateMap<ProjectRequest, Project>()
                .ConstructUsing((ProjectRequest pr) => Project.Create(pr.Name, pr.interns, pr.CreatedAt, null));

            CreateMap<Project, ProjectResponse>()
                .ConstructUsing((Project p) => new ProjectResponse(p.Id, p.Name, p.InternIds.ToList(), p.CreatedAt, p.UpdatedAt));
        }
    }
}
