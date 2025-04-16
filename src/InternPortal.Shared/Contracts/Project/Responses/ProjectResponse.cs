using InternPortal.Shared.Contracts.Intern.Responses;


namespace InternPortal.Shared.Contracts.Project.Responses
{
    public sealed record ProjectResponse(
    Guid Id,
    string Name,
    List<Guid> InternIds,
    DateTime CreateAt,
    DateTime UpdateAt);
}
