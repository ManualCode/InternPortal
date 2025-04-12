using AutoMapper;
using InternPortal.Infrastructure.Mappers.Profiles;


namespace InternPortal.Infrastructure.Mappers
{
    public class Mapping
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<InternMapperProfile>();
                cfg.AddProfile<InternshipMapperProfile>();
                cfg.AddProfile<ProjectMapperProfile>();

            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }
    
}
