using InternPortal.Infrastructure.Entities;
using InternPortal.Domain.Filters;



namespace InternPortal.Infrastructure.Extensions
{
    public static class InternExtensions
    {
        public static IQueryable<InternEntity> Filter(this IQueryable<InternEntity> query, InternFilter internFilter)
        {
            if (internFilter is not null && !string.IsNullOrWhiteSpace(internFilter.Internship))
                query = query.Where(x => x.Internship.Name.ToLower() == internFilter.Internship.ToLower());

            if (internFilter is not null && !string.IsNullOrWhiteSpace(internFilter.Project))
                query = query.Where(x => x.Project.Name.ToLower() == internFilter.Project.ToLower());

            return query;
        }
    }
}
