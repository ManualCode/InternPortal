using InternPortal.Shared.Contracts.Internship.Responses;
using InternPortal.Shared.Contracts.Internship.Requests;
using InternPortal.Shared.Contracts.Project.Responses;
using InternPortal.Shared.Contracts.Intern.Responses;
using InternPortal.Infrastructure.Entities;
using InternPortal.Domain.Models;
using AutoMapper;


namespace InternPortal.Infrastructure.Mappers.Profiles
{
    public class InternshipMapperProfile : Profile
    {
        public InternshipMapperProfile()
        {
            CreateMap<InternshipEntity, Internship>()
                 .ConstructUsing((InternshipEntity ie) => Internship.Create(ie.Name, ie.Interns.Select(x => x.Id).ToList(), ie.CreatedAt, ie.Id))
                 .PreserveReferences();

            CreateMap<Internship, InternshipEntity>();

            CreateMap<InternshipRequest, Internship>()
                .ConstructUsing((InternshipRequest ir) => Internship.Create(ir.Name, ir.interns, ir.CreatedAt, null));

            CreateMap<Internship, InternshipResponse>()
                .ConstructUsing((Internship i) => new InternshipResponse(i.Id, i.Name, i.InternIds.ToList(), i.CreatedAt, i.UpdatedAt));
        }
    }
}
