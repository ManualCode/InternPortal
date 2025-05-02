using InternPortal.Shared.Contracts.Internship.Responses;
using InternPortal.Shared.Contracts.Project.Responses;

namespace InternPortal.Shared.Contracts.Intern.Responses
{
    public sealed record InternResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Gender,
    DateTime BirthDate,
    string Email,
    string? PhoneNumber,
    string Internship,
    string Project,
    DateTime CreateAt,
    DateTime UpdateAt);
}
