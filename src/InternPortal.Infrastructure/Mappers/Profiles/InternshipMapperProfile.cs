using InternPortal.Shared.Contracts.Internship.Responses;
using InternPortal.Shared.Contracts.Internship.Requests;
using InternPortal.Domain.Models;
using AutoMapper;



namespace InternPortal.Infrastructure.Mappers.Profiles
{
    public class InternshipMapperProfile : Profile
    {
        public InternshipMapperProfile()
        {
            CreateMap<InternshipRequest, Internship>()
                .ConstructUsing((InternshipRequest ir) => new Internship { Id = Guid.NewGuid(), Name = ir.Name, InternIds = ir.interns, CreatedAt = ir.CreateAt, UpdatedAt = ir.UpdateAt})
                .ForMember(dest => dest.Interns, opt => opt.Ignore());

            CreateMap<Internship, InternshipResponse>()
                .ConstructUsing((Internship i) => new InternshipResponse(i.Id, i.Name, i.Interns.Select(x => x.Id).ToList(), i.CreatedAt, i.UpdatedAt))
                .ForMember(dest => dest.Interns, opt => opt.Ignore());

            CreateMap<PagedResult<Internship>, PagedInternshipResponse>()
                .ConstructUsing((PagedResult<Internship> i) => new PagedInternshipResponse(i.TotalCount, i.Data.Select(Mapping.Mapper.Map<InternshipResponse>).ToList()));
        }
    }
}
