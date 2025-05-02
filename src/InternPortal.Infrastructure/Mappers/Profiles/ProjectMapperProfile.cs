using AutoMapper;
using InternPortal.Domain.Models;
using InternPortal.Shared.Contracts.Project.Requests;
using InternPortal.Shared.Contracts.Project.Responses;
using System.Net.Http.Headers;


namespace InternPortal.Infrastructure.Mappers.Profiles
{
    public class ProjectMapperProfile : Profile
    {
        public ProjectMapperProfile()
        {
            CreateMap<ProjectRequest, Project>()
                .ConstructUsing((ProjectRequest pr) => new Project {Id = Guid.NewGuid(), Name = pr.Name, InternIds = pr.interns, CreatedAt = pr.CreateAt, UpdatedAt = pr.UpdateAt})
                .ForMember(dest => dest.Interns, opt => opt.Ignore());

            CreateMap<Project, ProjectResponse>()
                .ConstructUsing((Project p) => new ProjectResponse(p.Id, p.Name, p.Interns.Select(x => x.Id).ToList(), p.CreatedAt, p.UpdatedAt))
                .ForMember(dest => dest.Interns, opt => opt.Ignore());

            CreateMap<PagedResult<Project>, PagedProjectResponse>()
                .ConstructUsing((PagedResult<Project> p) => new PagedProjectResponse(p.TotalCount, p.Data.Select(Mapping.Mapper.Map<ProjectResponse>).ToList()));
        }
    }
}
