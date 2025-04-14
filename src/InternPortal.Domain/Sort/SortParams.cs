using InternPortal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternPortal.Domain.Sort
{
    public class SortParams
    {
        public string OrderBy { get; set; }
        public SortDirection SortDirection { get; set; }
    }
}
