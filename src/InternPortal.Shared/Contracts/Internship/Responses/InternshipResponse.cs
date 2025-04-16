namespace InternPortal.Shared.Contracts.Internship.Responses
{
    public sealed record InternshipResponse(
    Guid Id,
    string Name,
    List<Guid> InternIds,
    DateTime CreateAt,
    DateTime UpdateAt);
}
