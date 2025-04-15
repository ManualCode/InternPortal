using System.ComponentModel.DataAnnotations;


namespace InternPortal.Shared.Contracts.Internship.Requests
{
    public sealed record InternshipRequest(
        [Required]
        string Name,
        DateTime CreatedAt
    );
}
