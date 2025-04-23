using System.ComponentModel.DataAnnotations;


namespace InternPortal.Shared.Contracts.Internship.Requests
{
    public sealed record InternshipRequest(
        [Required]
        string Name,
        List<Guid> interns,
        DateTime CreateAt,
        DateTime UpdateAt
    );
}
