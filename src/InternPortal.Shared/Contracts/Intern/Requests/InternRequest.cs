namespace InternPortal.Shared.Contracts.Intern.Requests
{
    public sealed record InternRequest(
        string FirstName,
        string LastName,
        string Gender,
        string Email,
        string PhoneNumber,
        DateTime BirthDate,
        string Internship,
        string Project,
        DateTime CreatedAt,
        DateTime UpdateAt
    );
}
