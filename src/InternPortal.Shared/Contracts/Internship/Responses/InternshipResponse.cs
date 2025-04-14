using InternPortal.Shared.Contracts.Intern.Responses;


namespace InternPortal.Shared.Contracts.Internship.Responses
{
    public sealed record InternshipResponse(
    Guid Id,
    string Name,
    List<InternResponse> Inters,
    DateTime CreateAt,
    DateTime UpdateAt);
}
