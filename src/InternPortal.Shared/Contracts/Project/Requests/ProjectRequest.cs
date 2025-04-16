using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternPortal.Shared.Contracts.Project.Requests
{
    public sealed record ProjectRequest(
        [Required]
        string Name,
        List<Guid> interns,
        DateTime CreatedAt,
        DateTime UpdateAt
    );
}
