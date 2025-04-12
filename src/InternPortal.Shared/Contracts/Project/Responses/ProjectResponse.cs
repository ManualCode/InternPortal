using InternPortal.Shared.Contracts.Intern.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternPortal.Shared.Contracts.Project.Responses
{
    public sealed record ProjectResponse(
    Guid Id,
    string Name,
    List<InternResponse> Inters,
    DateTime CreateAt,
    DateTime UpdateAt);
}
