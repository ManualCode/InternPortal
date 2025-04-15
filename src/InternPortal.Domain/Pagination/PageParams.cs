using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternPortal.Domain.Pagination
{
    public class PageParams
    {
        public int? Page { get; set; }

        public int? PageSize { get; set; }
    }
}
