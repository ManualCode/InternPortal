namespace InternPortal.Shared.Contracts.Project.Responses
{
    public sealed record ProjectResponse(
    Guid Id,
    string Name,
    List<Guid> Interns,
    DateTime CreateAt,
    DateTime UpdateAt);

    public sealed record PagedProjectResponse(

       int TotalCount,
       List<ProjectResponse> Projects);
}
