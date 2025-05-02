using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternPortal.Domain.Models
{
    public class PagedResult<T>
    {
        public int TotalCount { get; }
        public ICollection<T> Data { get; set; }

        public PagedResult(int totalCount, ICollection<T> data)
        {
            TotalCount = totalCount;
            Data = data;
        }
    }
}
