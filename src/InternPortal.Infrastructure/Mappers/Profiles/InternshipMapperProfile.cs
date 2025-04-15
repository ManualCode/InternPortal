using AutoMapper;
using InternPortal.Domain.Models;
using InternPortal.Infrastructure.Entities;
using InternPortal.Shared.Contracts.Intern.Responses;
using InternPortal.Shared.Contracts.Internship.Requests;
using InternPortal.Shared.Contracts.Internship.Responses;
using InternPortal.Shared.Contracts.Project.Requests;
using InternPortal.Shared.Contracts.Project.Responses;


namespace InternPortal.Infrastructure.Mappers.Profiles
{
    public class InternshipMapperProfile : Profile
    {
        public InternshipMapperProfile()
        {
            CreateMap<InternshipEntity, Internship>()
                 .ConstructUsing((InternshipEntity ie) => Internship.Create(ie.Name,
                ie.Interns.Select(x => Intern.Create(x.FirstName, x.LastName, (Gender)x.Gender, x.Email, x.PhoneNumber, x.BirthDate, null, null, x.CreatedAt)).ToList(),
                ie.CreatedAt, ie.Id))
                 .PreserveReferences();

            CreateMap<Internship, InternshipEntity>();

            CreateMap<InternshipRequest, Internship>()
                .ConstructUsing((InternshipRequest ir) => Internship.Create(ir.Name, null, ir.CreatedAt, null));

            CreateMap<Internship, InternshipResponse>()
                .ConstructUsing((Internship i) => new InternshipResponse(i.Id, i.Name,
                i.Interns.Select(x =>
                new InternResponse(x.Id, $"{x.FirstName} {x.LastName}", x.Email, x.PhoneNumber, null,
                new ProjectResponse(x.Project.Id, x.Project.Name, new List<InternResponse>(), x.Project.CreatedAt, x.Project.UpdatedAt),
                x.CreatedAt, x.UpdatedAt)).ToList(),
                i.CreatedAt, i.UpdatedAt));
        }
    }
}
