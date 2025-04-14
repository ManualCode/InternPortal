using InternPortal.Domain.Filters;
using InternPortal.Domain.Models;
using InternPortal.Domain.Sort;
using InternPortal.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InternPortal.Infrastructure.Extensions
{
    public static class InternshipExtensions
    {
        public static IQueryable<InternshipEntity> Filter(this IQueryable<InternshipEntity> query, InternshipFilter internshipFilter)
        {
            if (internshipFilter is not null && !string.IsNullOrWhiteSpace(internshipFilter.Name))
                query = query.Where(x => x.Name.ToLower() == internshipFilter.Name.ToLower());

            return query;
        }

        public static IQueryable<InternshipEntity> Sort(this IQueryable<InternshipEntity> query, SortParams sort)
        {
            return sort.SortDirection == SortDirection.Descending
                ? query.OrderByDescending(GetKeySelector(sort.OrderBy))
                : query.OrderBy(GetKeySelector(sort.OrderBy));
        }

        private static Expression<Func<InternshipEntity, object>> GetKeySelector(string orderBy)
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
