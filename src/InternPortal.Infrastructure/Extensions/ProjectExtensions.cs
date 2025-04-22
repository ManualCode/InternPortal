using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;
using InternPortal.Domain.Pagination;
using InternPortal.Domain.Sort;
using InternPortal.Infrastructure.Entities;
using System.Linq.Expressions;


namespace InternPortal.Infrastructure.Extensions
{
    public static class ProjectExtensions
    {
        public static IQueryable<ProjectEntity> Page(this IQueryable<ProjectEntity> query, PageParams pageParams)
        {
            if (pageParams == null) return query;
            var page = pageParams.Page ?? 1;
            var pageSize = pageParams.PageSize ?? 10;

            var skip = (page - 1) * pageSize;
            return query.Skip(skip).Take(pageSize);
        }

        public static IQueryable<ProjectEntity> Filter(this IQueryable<ProjectEntity> query, BaseFilter ProjectFilter)
        {
            if (ProjectFilter is not null && !string.IsNullOrWhiteSpace(ProjectFilter.Name))
                query = query.Where(x => x.Name.ToLower().Contains(ProjectFilter.Name.ToLower()));

            return query;
        }

        public static IQueryable<ProjectEntity> Sort(this IQueryable<ProjectEntity> query, SortParams sort)
        {
            return sort.SortDirection == SortDirection.Descending
                ? query.OrderByDescending(GetKeySelector(sort.OrderBy))
                : query.OrderBy(GetKeySelector(sort.OrderBy));
        }

        private static Expression<Func<ProjectEntity, object>> GetKeySelector(string orderBy)
        {
            if (string.IsNullOrEmpty(orderBy))
                return x => x.CreatedAt;

            return orderBy switch
            {
                nameof(InternshipEntity.Name) => x => x.Name,
                nameof(InternshipEntity.Interns) => x => x.Interns.Count,
                _ => x => x.UpdatedAt
            };
        }
    }
}
