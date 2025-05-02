using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;



namespace InternPortal.Infrastructure.Extensions
{
    public static class InternExtensions
    {
        public static IQueryable<Intern> Filter(this IQueryable<Intern> query, InternFilter internFilter)
        {
            if (internFilter is not null && !string.IsNullOrWhiteSpace(internFilter.Internship))
                query = query.Where(x => x.Internship.Name.ToLower() == internFilter.Internship.ToLower());

            if (internFilter is not null && !string.IsNullOrWhiteSpace(internFilter.Project))
                query = query.Where(x => x.Project.Name.ToLower() == internFilter.Project.ToLower());

            return query;
        }
    }
}
