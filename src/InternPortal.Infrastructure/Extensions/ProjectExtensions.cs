using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;
using InternPortal.Domain.Pagination;
using InternPortal.Domain.Sort;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace InternPortal.Infrastructure.Extensions
{
    public static class ProjectExtensions
    {
        public static async Task<PagedResult<Project>> Page(this IQueryable<Project> query, PageParams pageParams)
        {
            var count = await query.CountAsync();
            if (count == 0) return new PagedResult<Project>(count, []);

            var page = pageParams.Page ?? 1;
            var pageSize = pageParams.PageSize ?? 10;
            var skip = (page - 1) * pageSize;

            return new PagedResult<Project>(count, await query.Skip(skip).Take(pageSize).ToListAsync());
        }

        public static IQueryable<Project> Filter(this IQueryable<Project> query, BaseFilter ProjectFilter)
        {
            if (ProjectFilter is not null && !string.IsNullOrWhiteSpace(ProjectFilter.Name))
                query = query.Where(x => x.Name.ToLower().Contains(ProjectFilter.Name.ToLower()));

            return query;
        }

        public static IQueryable<Project> Sort(this IQueryable<Project> query, SortParams sort)
        {
            return sort.SortDirection == SortDirection.Descending
                ? query.OrderByDescending(GetKeySelector(sort.OrderBy))
                : query.OrderBy(GetKeySelector(sort.OrderBy));
        }

        private static Expression<Func<Project, object>> GetKeySelector(string orderBy)
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
