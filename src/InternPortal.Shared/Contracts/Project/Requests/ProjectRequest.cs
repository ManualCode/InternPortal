using System.ComponentModel.DataAnnotations;

namespace InternPortal.Shared.Contracts.Project.Requests
{
    public sealed record ProjectRequest(
        [Required]
        string Name,
        List<Guid> interns,
        DateTime CreateAt,
        DateTime UpdateAt
    );
}
