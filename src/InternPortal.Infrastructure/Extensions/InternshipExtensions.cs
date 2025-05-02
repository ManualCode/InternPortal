using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;
using InternPortal.Domain.Pagination;
using InternPortal.Domain.Sort;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace InternPortal.Infrastructure.Extensions
{
    public static class InternshipExtensions
    {
        public static async Task<PagedResult<Internship>> Page(this IQueryable<Internship> query, PageParams pageParams)
        {
            var count = await query.CountAsync();
            if (count == 0) return new PagedResult<Internship>(count, []);

            var page = pageParams.Page ?? 1;
            var pageSize = pageParams.PageSize ?? 10;
            var skip = (page -1 ) * pageSize;

            return new PagedResult<Internship>(count, await query.Skip(skip).Take(pageSize).ToListAsync());
        }

        public static IQueryable<Internship> Filter(this IQueryable<Internship> query, BaseFilter internshipFilter)
        {
            if (internshipFilter is not null && !string.IsNullOrWhiteSpace(internshipFilter.Name))
                query = query.Where(x => x.Name.ToLower().Contains(internshipFilter.Name.ToLower()));

            return query;
        }

        public static IQueryable<Internship> Sort(this IQueryable<Internship> query, SortParams sort)
        {
            return sort.SortDirection == SortDirection.Descending
                ? query.OrderByDescending(GetKeySelector(sort.OrderBy))
                : query.OrderBy(GetKeySelector(sort.OrderBy));
        }

        private static Expression<Func<Internship, object>> GetKeySelector(string orderBy)
        {
            if (string.IsNullOrEmpty(orderBy))
                return x => x.CreatedAt;

            return orderBy switch
            {
                nameof(Internship.Name) => x => x.Name,
                nameof(Internship.Interns) => x => x.Interns.Count,
                _ => x => x.UpdatedAt
            };
        }
    }
}
