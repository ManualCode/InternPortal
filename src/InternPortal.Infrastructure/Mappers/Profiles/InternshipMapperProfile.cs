using AutoMapper;
using InternPortal.Domain.Models;
using InternPortal.Infrastructure.Entities;


namespace InternPortal.Infrastructure.Mappers.Profiles
{
    public class InternshipMapperProfile : Profile
    {
        public InternshipMapperProfile()
        {
            CreateMap<InternshipEntity, Internship>()
                 .ConstructUsing((InternshipEntity ie) => Internship.Create(ie.Id, ie.Name,
                ie.Interns.Select(x => Intern.Create(x.FirstName, x.LastName, (Gender)x.Gender, x.Email, x.PhoneNumber, x.BirthDate, null, null, x.CreatedAt).Intern).ToList(),
                ie.CreatedAt).Internship)
                 .PreserveReferences();

            CreateMap<Internship, InternshipEntity>();
        }
    }
}
